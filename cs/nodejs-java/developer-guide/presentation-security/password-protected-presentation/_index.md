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

Otevírací heslo šifruje prezentaci. Správné heslo je vyžadováno pro načtení a zobrazení obsahu prezentace, takže tato ochrana poskytuje důvěrnost.

Otevírací heslo se liší od hesla pro ochranu proti zápisu. Ochrana proti zápisu omezuje úpravy, ale nešifruje obsah ani nebrání načtení prezentace. Pro správu hesel pro úpravu prezentací viz [Write-Protect Presentations](/slides/cs/nodejs-java/write-protected-presentation/).

Níže uvedené pracovní postupy platí pro prezentace PPT i PPTX. Příklady používají oba formáty, kde je důležité jejich chování založené na souborech i na streamu.

## **Zašifrovat prezentaci otevíracím heslem**

Použijte [ProtectionManager.encrypt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/protectionmanager/#encrypt) k přiřazení otevíracího hesla. Pak použijte [Presentation.save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#save) k uložení zašifrované prezentace.

Následující příklad zašifruje prezentaci PPTX:

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

## **Načíst zašifrovanou prezentaci**

Nastavte [LoadOptions.setPassword](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#setPassword) na otevírací heslo a předávejte možnosti při načítání souboru pomocí [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/). Načítání selže, když je požadováno otevírací heslo, ale poskytnuté heslo chybí nebo je nesprávné.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Práce s dešifrovanou prezentací.
} finally {
    presentation.dispose();
}
```

## **Odstranit šifrování z prezentace**

Načtěte prezentaci s jejím otevíracím heslem, zavolejte [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/protectionmanager/#removeEncryption) a výsledek uložte. Uložená prezentace pak může být načtena bez hesla.

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

## **Ověřit otevírací heslo před načtením**

Použijte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) k získání [PresentationInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/) bez vytváření kompletní instance prezentace. Zkontrolujte [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) před požádáním o heslo nebo jeho ověřením. Pokud je ochrana přítomna, ověřte zadanou hodnotu pomocí [PresentationInfo.checkPassword](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/#checkPassword).

### **Pracovní postup se souborovou cestou**

Následující příklad ověří otevírací heslo pro soubor PPTX, předá ověřenou hodnotu do [LoadOptions.setPassword](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#setPassword) a poté načte kompletní prezentaci:

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "protected-presentation.pptx";
const password = "open_password";
const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    console.log("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    console.log("The opening password is not correct.");
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

### **Pracovní postup se streamem**

Použijte [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) k prozkoumání čitelného streamu Node.js. Po spotřebování inspečního streamu vytvořte nový stream před načtením kompletní prezentace pomocí [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#createPresentationFromStream).

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

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/#checkPassword) vrací `true` pouze tehdy, když má prezentace otevírací heslo a zadané heslo je správné. V každém z následujících případů vrací `false`:

- Heslo je nesprávné.
- Prezentace nemá otevírací heslo.
- Zadané heslo je `null` nebo prázdné.

Chování je stejné pro prezentace PPT i PPTX.

## **Zkontrolovat, zda je načtená prezentace zašifrovaná**

Po načtení prezentace se správným heslem zkontrolujte [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/protectionmanager/#isEncrypted), abyste potvrdili, že původní prezentace byla šifrována. Pro detekci ochrany otevíracím heslem před načtením použijte [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) jako výše.

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
Nezapisujte otevírací hesla do protokolů ani je nezahrnujte do diagnostických zpráv. Vyhněte se zbytečným opakovaným pokusům o ověření, uchovávejte hesla v paměti jen po nezbytně nutnou dobu a při okamžitém načtení prezentace znovu použijte úspěšný výsledek ověření.
{{% /alert %}}

## **Ochrana prezentace heslem online**

1. Otevřete aplikaci [Aspose.Slides Lock](https://products.aspose.app/slides/cs/lock).
1. Vyberte nebo nahrajte prezentaci.
1. Zadejte heslo pro ochranu při prohlížení.
1. Volitelně zadejte samostatné heslo pro ochranu při úpravách.
1. Použijte ochranu a stáhněte výsledný soubor.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/cs/nodejs-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/cs/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Jaký je rozdíl mezi otevíracím heslem a heslem pro ochranu proti zápisu?**

Otevírací heslo šifruje prezentaci a je vyžadováno pro načtení jejího obsahu. Heslo pro ochranu proti zápisu omezuje úpravy bez šifrování obsahu.

**Mohu ověřit otevírací heslo bez načtení všech snímků?**

Ano. Získejte informace o prezentaci, zjistěte, zda je přítomna ochrana otevíracím heslem, a ověřte heslo před vytvořením kompletní instance prezentace.

**Podporují pracovní postupy pro kontrolu hesla jak PPT, tak PPTX?**

Ano. Detekce a ověření hesla založené na cestě k souboru i na streamu se chovají stejně pro prezentace PPT i PPTX.