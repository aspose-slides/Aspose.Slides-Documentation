---
title: Přidání digitálních podpisů do prezentací v JavaScriptu
linktitle: Digitální podpis
type: docs
weight: 10
url: /cs/nodejs-java/digital-signature-in-powerpoint/
keywords:
- digitální podpis
- digitální certifikát
- certifikační autorita
- PFX certifikát
- PKCS#12
- ověření podpisu
- PowerPoint
- PPTX
- zabezpečení prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se, jak podepsat existující PPTX prezentace pomocí PFX certifikátů a použít Aspose.Slides pro Node.js prostřednictvím Javy k ověření nebo odstranění digitálních podpisů."
---
## **Přehled**

Digitální podpis pomáhá příjemci určit, kdo prezentaci podepsal a zda se podepsaný obsah změnil. Tři související bezpečnostní pojmy jsou zde důležité:

- **digitální certifikát** je elektronické oprávnění, které spojuje identitu s veřejným klíčem. Důvěryhodná certifikační autorita (CA) může certifikát vydat, nebo organizace může použít samopodepsaný certifikát pro interní pracovní postupy.
- **digitální podpis** je vytvořen z obsahu prezentace a soukromého klíče držitele certifikátu. Veřejný klíč certifikátu pak může být použit k ověření podpisu. Podpis poskytuje důkaz o původu a integritě; nešifruje prezentaci.
- **Ochrana heslem** určuje, zda může uživatel otevřít nebo upravit prezentaci. Je oddělena od digitálního podepisování a je popsána v [Prezentace chráněné heslem](/nodejs-java/password-protected-presentation/).

PowerPoint poskytuje příkaz **Přidat digitální podpis** v nabídce **Soubor > Informace > Chrání prezentaci**.

![PowerPoint nabídka Ochrana prezentace s vyznačeným Přidat digitální podpis](add-digital-signature-in-powerpoint.png)

Po otevření podepsané prezentace může PowerPoint zobrazit upozornění o stavu podpisu.

![Upozornění PowerPointu, že prezentace obsahuje platné podpisy](digital-signature-status-in-powerpoint.png)

Aspose.Slides zpřístupňuje podpisy prostřednictvím [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--), který vrací [DigitalSignatureCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/digitalsignaturecollection/) obsahující objekty [DigitalSignature](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/digitalsignature/). Prezentace může obsahovat více podpisů.

## **Pochopení PFX certifikátů a hesel**

Soubor PFX, také známý jako soubor PKCS#12 a běžně s příponou `.pfx` nebo `.p12`, může obsahovat certifikát X.509, jeho soukromý klíč a řetězec certifikátů. Soukromý klíč umožňuje držiteli vytvořit podpis. Certifikát bez dostupného soukromého klíče nelze použít k podepsání prezentace.

Heslo PFX chrání balíček certifikátu a soukromý klíč. Není to **heslo** pro otevírání nebo úpravu prezentace. Nezapisujte soubory PFX ani jejich hesla do správy verzí. V produkci omezte přístup k souboru certifikátu a získejte jeho heslo z tajného úložiště nebo jiného chráněného konfiguračního zdroje. Níže uvedené příklady používají proměnnou prostředí pouze proto, aby se heslo neukládalo přímo v kódu.

## **Přidání digitálního podpisu do prezentace**

Pro podepsání reálného pracovního postupu s prezentací načtěte existující soubor PPTX, vytvořte [DigitalSignature](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/digitalsignature/) z PFX certifikátu a jeho hesla, přidejte podpis do kolekce prezentace a uložte do souboru PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const certificatePassword = process.env.PFX_PASSWORD;
if (!certificatePassword) {
    throw new Error("Set the PFX_PASSWORD environment variable.");
}

const presentation = new slides.Presentation("InputPresentation.pptx");
try {
    const signature = new slides.DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Uložení výsledku pod novým názvem zachová neoznačený zdrojový soubor. Hodnota nastavená pomocí [DigitalSignature.setComments](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/digitalsignature/) popisuje účel podpisu; nejde o bezpečnostní kontrolu.

## **Ověření digitálních podpisů**

Když načtete podepsaný soubor PPTX, prohlédněte každou položku vrácenou metodou [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--). Metoda [DigitalSignature.isValid](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/digitalsignature/) udává, zda je vložený podpis platný pro aktuální obsah prezentace.

Následující příklad také používá třídu Node.js `X509Certificate` k přečtení jména subjektu z každého vloženého certifikátu.

```javascript
const { X509Certificate } = require("node:crypto");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    const signatures = presentation.getDigitalSignatures();
    const signatureCount = signatures.size();

    if (signatureCount === 0) {
        console.log("The presentation does not contain digital signatures.");
    } else {
        let allSignaturesAreValid = true;

        for (let index = 0; index < signatureCount; index++) {
            const signature = signatures.get_Item(index);
            const signatureIsValid = signature.isValid();
            const signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            const signTime = signature.getSignTime().toString();

            const certificateData = signature.getCertificate();
            const certificate = new X509Certificate(Buffer.from(certificateData));
            const signerName = certificate.subject;

            console.log(`${signerName}, ${signTime} -- ${signatureStatus}`);

            allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
        }

        if (allSignaturesAreValid) {
            console.log("All embedded signatures are valid for the current presentation.");
        } else {
            console.log("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

Neplatný výsledek obvykle znamená, že po podepsání byl změněn obsah prezentace nebo data podpisu, nebo že soubor je poškozen. Odebrání všech podpisů vytvoří neoznačenou prezentaci, takže kontrola pouze platnosti položek není dostatečná: workflow citlivé na bezpečnost musí také ověřit, že je přítomen očekávaný počet podpisů a očekávané identity podepisujících.

Tento výsledek platnosti by neměl být považován za úplné rozhodnutí o důvěře certifikátu. V závislosti na vaší bezpečnostní politice může vaše aplikace také potřebovat vytvořit a ověřit řetězec certifikátů X.509, zkontrolovat data platnosti certifikátu a stav revokace, potvrdit očekávaný subjekt nebo otisk, ověřit použití klíče a vyhodnotit důvěryhodné časové razítko. Hodnota [DigitalSignature.getSignTime](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/digitalsignature/) sama o sobě není důkaz od důvěryhodné autority časových razítek.

## **Odstranění digitálních podpisů**

Odstranění podpisů mění bezpečnostní stav prezentace. Následující příklad načte podepsaný soubor PPTX, odstraní všechny podpisy pomocí [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/digitalsignaturecollection/clear/), a uloží neoznačenou kopii.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pro odstranění pouze jednoho podpisu zavolejte [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) s jeho nulovým indexem. Uložte do nového souboru, pokud není přepsání původního podepsaného souboru explicitní součástí vašeho pracovního postupu.

## **Úpravy a formátové úvahy**

- Podpis nečiní prezentaci jen pro čtení. Uživatelé i aplikace mohou soubor stále upravovat, ale změny podepsaného obsahu obvykle zneplatní stávající podpis.
- Dokončete všechny zamýšlené úpravy před podepsáním. Pokud je nutné prezentaci změnit, uložte upravenou verzi a podepište ji znovu.
- Uchovávejte finální výstup ve formátu PPTX. Převod podepsané prezentace do jiného formátu nepřenáší původní PPTX podpis jako platný podpis pro konvertovaný soubor.
- Považujte soukromý klíč certifikátu za citlivý. Každý, kdo získá soukromý klíč a jeho heslo, může vytvořit podpisy, které se jeví jako pocházející od držitele certifikátu.
- Uchovávejte neoznačený zdroj nebo jinou kontrolovanou kopii, pokud to vyžaduje vaše politika uchovávání dokumentů.

## **Často kladené otázky**

**Šifruje digitální podpis prezentaci?**

Ne. Digitální podpis poskytuje důkaz o původu a integritě, ale obsah prezentace zůstává čitelný, pokud není použita samostatná šifrování. Použijte [ochranu heslem](/nodejs-java/password-protected-presentation/), když je nutné omezit přístup k obsahu.

**Je heslo PFX stejné jako heslo prezentace?**

Ne. Heslo PFX odemyká soukromý klíč uložený v balíčku certifikátu. Nereguluje, kdo může otevřít nebo upravit soubor PPTX.

**Mohu použít samopodepsaný certifikát?**

Technicky lze použít samopodepsaný certifikát, pokud obsahuje přístupný soukromý klíč. Příjemci jej nebudou automaticky důvěřovat, pokud není tento certifikát výslovně přidán do jejich důvěryhodného prostředí. Veřejné nebo meziorganizační workflow obecně používají certifikát vydaný důvěryhodnou certifikační autoritou.

**Co způsobuje, že je podpis neplatný?**

Změna podepsaného obsahu prezentace nebo dat podpisu po podepsání může podpis zneplatnit. Poškození souboru může také způsobit selhání ověření. Pokud jsou všechny podpisy odstraněny, prezentace je neoznačená, nikoli soubor obsahující neplatný podpis.

**Znamená platný podpis, že bych měl důvěřovat podepisovateli?**

Ne, samotné. Integrita podpisu a důvěra v podepisovatele jsou samostatná rozhodnutí. Politika ověřování v produkci by měla také kontrolovat řetězec certifikátů, období platnosti, stav revokace, očekávanou identitu, použití klíče a jakékoli požadavky na důvěryhodné časové razítko.

**Co se stane, když certifikát vyprší?**

Vypršení platnosti certifikátu nemění bajty prezentace, ale ovlivňuje hodnocení důvěry certifikátu. Zda podpis zůstane akceptovatelný, závisí na vaší politice a na tom, zda platné důvěryhodné časové razítko prokazuje, že podpis byl proveden, když byl certifikát platný. Nespoléhejte se pouze na zobrazený čas podpisu jako na důvěryhodné časové razítko.

**Může být podepsaná prezentace stále upravována?**

Ano. Podepsání neblokuje soubor. Úprava podepsaného obsahu obecně způsobí neplatnost stávajícího podpisu, takže nejprve dokončete prezentaci a podepište finální revizi.

**Může prezentace obsahovat více než jeden podpis?**

Ano. Přidejte každý podpis do kolekce vrácené metodou [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) před uložením. Během ověřování prohlédněte každý podpis a potvrďte, že jsou přítomni všichni požadovaní podepisující.

**Které formáty prezentací podporují tyto operace?**

Aspose.Slides podporuje operace s digitálním podpisem popsané zde pouze pro formát PPTX. Formáty PPT a OpenDocument nejsou tímto API workflow podporovány.

**Mohu odstranit podpis, aniž by to ovlivnilo snímky?**

Ano. Můžete odstranit jeden podpis nebo vyprázdnit celou kolekci a pak uložit prezentaci. Obsah snímků zůstává zachován, ale uložený soubor již neobsahuje důkaz o odstraněném podpisu.