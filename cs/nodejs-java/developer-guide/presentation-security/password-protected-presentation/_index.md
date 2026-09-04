---
title: Ochrana prezentací heslem v JavaScriptu
linktitle: Ochrana heslem
type: docs
weight: 20
url: /cs/nodejs-java/password-protected-presentation/
keywords:
- prezentace chráněná heslem
- otevírací heslo
- šifrovat PowerPoint
- dešifrovat PowerPoint
- ověřit heslo prezentace
- zkontrolovat heslo prezentace
- otevřít zašifrovanou prezentaci
- odstranit šifrování
- PowerPoint
- PPT
- PPTX
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Šifrujte, detekujte, ověřujte, otevírejte a dešifrujte prezentace PowerPoint PPT a PPTX chráněné heslem v JavaScriptu pomocí Aspose.Slides."
---
## **Přehled**

Otevírací heslo šifruje prezentaci. Správné heslo je vyžadováno k načtení a zobrazení obsahu prezentace, takže tato ochrana poskytuje důvěrnost.

Otevírací heslo se liší od hesla pro zápisovou ochranu. Ochrana proti zápisu omezuje úpravy, ale nešifruje obsah ani nebrání načtení prezentace. Pro správu hesel pro úpravu prezentací viz [Write-Protect Presentations](/slides/cs/nodejs-java/write-protected-presentation/).

Níže uvedené pracovní postupy platí pro prezentace PPT i PPTX. Příklady používají oba formáty, kde je důležité jejich chování při práci se soubory i streamy.

## **Šifrování prezentace pomocí otevíracího hesla**

Použijte [ProtectionManager.encrypt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/protectionmanager/#encrypt) k přiřazení otevíracího hesla. Poté použijte [Presentation.save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#save) k uložení zašifrované prezentace.

Následující příklad šifruje PPTX prezentaci:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nechávat vlastnosti dokumentu veřejné**

Ve výchozím nastavení zahrnuje Aspose.Slides vlastnosti dokumentu do šifrování prezentace. Metoda [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) řízení tohoto chování nezávisle na šifrování obsahu snímků. Před voláním [ProtectionManager.encrypt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/protectionmanager/#encrypt) předávejte `false`, pokud musí systém pro indexaci, klasifikaci, vyhledávání nebo správu dokumentů číst metadata bez otevíracího hesla.

Následující příklad vytvoří zašifrovanou PPTX prezentaci a zároveň nechá její vestavěné vlastnosti dokumentu veřejné:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Předání `false` metodě [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) neznamená, že snímky, mastery, rozložení, tvary, média nebo jiný obsah prezentace budou veřejné. Ovlivňuje pouze vlastnosti dokumentu. Pro čtení těchto vlastností bez načtení zašifrovaného obsahu viz [Manage Presentation Properties](/slides/cs/nodejs-java/presentation-properties/).

## **Načtení zašifrované prezentace**

Nastavte [LoadOptions.setPassword](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#setPassword) na otevírací heslo a předávejte možnosti metodě [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) při načítání souboru. Načtení selže, pokud je vyžadováno otevírací heslo, ale poskytnuté heslo chybí nebo je nesprávné.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Pracujte s dešifrovanou prezentací.
} finally {
    presentation.dispose();
}
```

## **Odstranění šifrování z prezentace**

Načtěte prezentaci s jejím otevíracím heslem, zavolejte [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/protectionmanager/#removeEncryption) a uložte výsledek. Uložená prezentace může být následně načtena bez hesla.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ověření otevíracího hesla před načtením**

Použijte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) k získání [PresentationInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/) bez vytváření kompletní instance prezentace. Před požádáním o heslo nebo jeho ověřením zkontrolujte [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected). Pokud je ochrana přítomna, ověřte poskytnutou hodnotu pomocí [PresentationInfo.checkPassword](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/#checkPassword).

### **Postup s cestou k souboru**

Následující příklad ověří otevírací heslo pro soubor PPTX, předá ověřenou hodnotu metodě [LoadOptions.setPassword](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#setPassword) a poté načte kompletní prezentaci:

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "protected-presentation.pptx";
const password = "open_password";
const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    console.log("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    console.log("The opening password is incorrect.");
} else {
    const loadOptions = new slides.LoadOptions();
    loadOptions.setPassword(password);

    const presentation = new slides.Presentation(filePath, loadOptions);
    try {
        console.log("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Postup se streamem**

Použijte [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) k prozkoumání čitelného streamu Node.js. Po spotřebování inspekčního streamu vytvořte nový stream před načtením kompletní prezentace pomocí [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#createPresentationFromStream).

Následující příklad používá soubor PPT:

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");

const filePath = "protected-presentation.ppt";
const password = "open_password";
const presentationFactory = slides.PresentationFactory.getInstance();
const infoStream = fs.createReadStream(filePath);

slides.PresentationFactory.getPresentationInfoFromStream(presentationFactory, infoStream, function(infoError, presentationInfo) {
    if (infoError) {
        console.log("The presentation information could not be read: " + infoError.message);
    } else if (!presentationInfo.isPasswordProtected()) {
        console.log("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        console.log("The opening password is incorrect.");
    } else {
        const loadOptions = new slides.LoadOptions();
        loadOptions.setPassword(password);
        const presentationStream = fs.createReadStream(filePath);

        slides.Presentation.createPresentationFromStream(presentationStream, loadOptions, function(loadError, presentation) {
            if (loadError) {
                console.log("The presentation could not be loaded: " + loadError.message);
            } else {
                try {
                    console.log("The presentation was validated and loaded successfully.");
                } finally {
                    presentation.dispose();
                }
            }
        });
    }
});
```

### **Návratové hodnoty metody checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/#checkPassword) vrací `true` pouze v případě, že prezentace má otevírací heslo a poskytnuté heslo je správné. Vrací `false` v každém z následujících případů:

- Heslo je nesprávné.
- Prezentace nemá otevírací heslo.
- Poskytnuté heslo je `null` nebo prázdné.

Chování je stejné pro prezentace PPT i PPTX.

## **Kontrola, zda je načtená prezentace zašifrována**

Po načtení prezentace se správným heslem zkontrolujte [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/protectionmanager/#isEncrypted), abyste potvrdili, že zdrojová prezentace byla zašifrována. Pro detekci ochrany otevíracím heslem před načtením použijte [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) podle výše uvedeného postupu.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const isEncrypted = presentation.getProtectionManager().isEncrypted();
    console.log("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Doporučení pro zabezpečení**

{{% alert color="warning" title="Security" %}}
Nezaznamenávejte otevírací hesla a nezahrnujte je do diagnostických zpráv. Vyhněte se zbytečným opakovaným pokusům o ověření, uchovávejte hesla v paměti jen po dobu nezbytně nutnou a při okamžitém načítání prezentace znovu použijte úspěšný výsledek ověření.
{{% /alert %}}

## **Zamknout prezentaci heslem online**

1. Otevřete aplikaci [Aspose.Slides Lock](https://products.aspose.app/slides/cs/lock).
2. Vyberte nebo nahrajte prezentaci.
3. Zadejte heslo pro ochranu zobrazení.
4. Volitelně zadejte samostatné heslo pro ochranu úprav.
5. Použijte ochranu a stáhněte výsledný soubor.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/cs/nodejs-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/cs/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Jaký je rozdíl mezi otevíracím heslem a heslem pro zápisovou ochranu?**

Otevírací heslo šifruje prezentaci a je vyžadováno k načtení jejího obsahu. Heslo pro zápisovou ochranu omezuje úpravy, aniž by šifrovalo obsah.

**Mohu ověřit otevírací heslo, aniž bych načetl všechny snímky?**

Ano. Získejte informace o prezentaci, zjistěte, zda je přítomna ochrana otevíracím heslem, a ověřte heslo před vytvořením kompletní instance prezentace.

**Může aplikace číst metadata bez otevíracího hesla?**

Ano, ale pouze pokud byla prezentace zašifrována s vypnutým šifrováním vlastností dokumentu. Aplikace pak musí použít režim načítání pouze s vlastnostmi dokumentu, popsaný v [Manage Presentation Properties](/slides/cs/nodejs-java/presentation-properties/).

**Podporují pracovní postupy pro kontrolu hesla jak PPT, tak PPTX?**

Ano. Detekce a ověřování hesla na základě cesty k souboru i streamu se chovají stejně pro prezentace PPT i PPTX.