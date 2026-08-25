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
- ověřit podpis
- PowerPoint
- PPTX
- zabezpečení prezentací
- Node.js
- JavaScript
- Aspose.Slides
description: "Zjistěte, jak podepsat existující PPTX prezentace pomocí PFX certifikátů a použít Aspose.Slides pro Node.js přes Java k ověření nebo odstranění digitálních podpisů."
---
## **Přehled**

Digitální podpis pomáhá příjemci zjistit, kdo prezentaci podepsal a zda se podepsaný obsah změnil. Tři související bezpečnostní koncepty jsou zde důležité:

- **Digitální certifikát** je elektronické oprávnění, které spojuje identitu s veřejným klíčem. Důvěryhodná certifikační autorita (CA) může certifikát vydat, nebo organizace může použít samopodepsaný certifikát pro interní pracovní postupy.
- **Digitální podpis** je vytvořen z obsahu prezentace a soukromého klíče držitele certifikátu. Veřejný klíč certifikátu lze pak použít k ověření podpisu. Podpis poskytuje důkaz o původu a integritě; nešifruje prezentaci.
- **Ochrana heslem** řídí, zda může uživatel otevřít nebo upravit prezentaci. Je oddělena od digitálního podepisování a je popsána v [Prezentace chráněné heslem](/slides/cs/nodejs-java/password-protected-presentation/).

PowerPoint nabízí příkaz **Add a Digital Signature** pod **File > Info > Protect Presentation**.

![Menu PowerPoint Ochrana prezentace s zvýrazněnou položkou Add a Digital Signature](add-digital-signature-in-powerpoint.png)

Po otevření podepsané prezentace může PowerPoint zobrazit oznámení o stavu podpisu.

![Upozornění PowerPoint uvádějící, že prezentace obsahuje platné podpisy](digital-signature-status-in-powerpoint.png)

Aspose.Slides zpřístupňuje podpisy prostřednictvím [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--), což vrací [DigitalSignatureCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/digitalsignaturecollection/), obsahující objekty [DigitalSignature](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/digitalsignature/). Prezentace může obsahovat více podpisů.

## **Pochopení PFX certifikátů a hesel**

Soubor PFX, také známý jako soubor PKCS#12 a běžně s příponou `.pfx` nebo `.p12`, může obsahovat X.509 certifikát, jeho soukromý klíč a řetězec certifikátů. Soukromý klíč umožňuje držiteli vytvořit podpis. Certifikát bez přístupného soukromého klíče nelze použít k podepsání prezentace.

Heslo PFX chrání balíček certifikátu a soukromý klíč. Není to **heslo** pro otevírání nebo úpravu prezentace. Nepřidávejte soubory PFX ani jejich hesla do zdrojového řízení. Ve výrobě omezte přístup k souboru certifikátu a získejte jeho heslo ze secret store nebo jiného chráněného konfiguračního zdroje. Níže uvedené příklady používají proměnnou prostředí pouze aby se vyhnuly vkládání hesla do kódu.

## **Přidání digitálního podpisu do prezentace**

Pro podepsání reálného pracovního postupu prezentace načtěte existující soubor PPTX, vytvořte [DigitalSignature](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/digitalsignature/) z PFX certifikátu a jeho hesla, přidejte podpis do kolekce prezentace a uložte jako soubor PPTX.

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

Uložení výsledku pod novým názvem zachovává neoznačený zdrojový soubor. Hodnota nastavená pomocí [DigitalSignature.setComments](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/digitalsignature/setComments/) popisuje účel podpisu; nejedná se o bezpečnostní kontrolu.

## **Ověření digitálních podpisů**

Když načtete podepsaný soubor PPTX, prozkoumejte každou položku vrácenou metodou [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--). Metoda [DigitalSignature.isValid](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/digitalsignature/isValid/) udává, zda je vložený podpis platný pro aktuální obsah prezentace.

Následující příklad také používá třídu Node.js `X509Certificate` k načtení názvu subjektu z každého vloženého certifikátu.

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

Neplatný výsledek obvykle znamená, že obsah podepsané prezentace nebo data podpisu se po podepsání změnily, nebo že soubor je poškozen. Odstranění všech podpisů vytvoří nepodepsanou prezentaci, takže kontrola pouze platnosti položek není dostačující: bezpečnostně citlivý pracovní postup musí také ověřit, že je přítomen očekávaný počet podpisů a očekávané identity podepisujících.

Tento výsledek platnosti by neměl být považován za úplné rozhodnutí o důvěře v certifikát. V závislosti na vaší bezpečnostní politice může vaše aplikace také potřebovat sestavit a ověřit řetězec certifikátů X.509, zkontrolovat datum platnosti certifikátu a stav revokace, potvrdit očekávaný subjekt nebo otisk, ověřit použití klíče a vyhodnotit důvěryhodný časový razítko. Hodnota [DigitalSignature.getSignTime](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/digitalsignature/getSignTime/) sama o sobě není důkaz od důvěryhodné autority časových razítek.

## **Odstranění digitálních podpisů**

Odstranění podpisů mění stav zabezpečení prezentace. Následující příklad načte podepsaný soubor PPTX, odstraní všechny podpisy pomocí [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/digitalsignaturecollection/clear/), a uloží neoznačenou kopii.

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

Pro odstranění pouze jednoho podpisu zavolejte [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) s jeho indexem začínajícím od nuly. Uložte do nového souboru, pokud není přepisování původního podepsaného souboru explicitní částí vašeho pracovního postupu.

## **Úvahy o úpravách a formátech**

- Podpis neznamená, že je prezentace jen pro čtení. Uživatelé a aplikace mohou soubor nadále upravovat, ale změny podepsaného obsahu obvykle zneplatní existující podpis.
- Dokončete všechny zamýšlené úpravy před podpisem. Pokud je nutné prezentaci změnit, uložte revidovanou verzi a tuto revizi podepište znovu.
- Udržujte finální výstup ve formátu PPTX. Převod podepsané prezentace do jiného formátu nepřenáší původní podpis PPTX jako platný podpis pro převedený soubor.
- Považujte soukromý klíč certifikátu za citlivý. Kdokoli, kdo získá soukromý klíč a jeho heslo, může vytvořit podpisy, které se jeví jako pocházející od držitele tohoto certifikátu.
- Uchovávejte neoznačený zdroj nebo jinou kontrolovanou kopii, pokud to vyžaduje vaše politika uchovávání dokumentů.

## **Často kladené otázky**

**Digitální podpis šifruje prezentaci?**

Ne. Digitální podpis poskytuje důkaz o původu a integritě, ale obsah prezentace zůstává čitelný, pokud není použita samostatná šifrování. Použijte [ochranu heslem](/slides/cs/nodejs-java/password-protected-presentation/), pokud je nutné omezit přístup k obsahu.

**Je heslo PFX stejné jako heslo prezentace?**

Ne. Heslo PFX odemyká soukromý klíč uložený v balíčku certifikátu. Nereguluje, kdo může otevřít nebo upravit soubor PPTX.

**Mohu použít samopodepsaný certifikát?**

Technicky lze samopodepsaný certifikát použít, pokud obsahuje přístupný soukromý klíč. Příjemci jej však nebudou automaticky důvěřovat, pokud tento certifikát není výslovně přidán do jejich důvěryhodného prostředí. Ve veřejných nebo mezioborových pracovních postupech se obvykle používá certifikát vydaný důvěryhodnou CA.

**Co způsobuje neplatnost podpisu?**

Změna podepsaného obsahu prezentace nebo dat podpisu po podepsání může podpis neplatnit. Poškození souboru může také způsobit selhání ověření. Pokud jsou odstraněny všechny podpisy, prezentace je nepodepsaná, nikoli soubor obsahující neplatný podpis.

**Znamená platný podpis, že bych měl důvěřovat podepisovateli?**

Není to samostatně. Integrita podpisu a důvěra v podepisovatele jsou samostatná rozhodnutí. Produkční validační politika by měla také kontrolovat řetězec certifikátů, období platnosti, stav revokace, očekávanou identitu, použití klíče a případné požadavky na důvěryhodné časové razítko.

**Co se stane, když certifikát vyprší?**

Vypršení platnosti certifikátu nemění bajty prezentace, ale ovlivňuje hodnocení důvěry v certifikát. Zda je podpis stále přijatelné, závisí na vaší politice a na tom, zda platné důvěryhodné časové razítko prokazuje, že podpis byl vytvořen, když byl certifikát platný. Nespoléhejte se pouze na zobrazený čas podpisu jako na důvěryhodné časové razítko.

**Lze podepsanou prezentaci stále upravovat?**

Ano. Podepsání soubor neuzamyká. Úprava podepsaného obsahu obvykle zneplatní existující podpis, proto dokončete prezentaci nejprve a podepište finální revizi.

**Může prezentace obsahovat více než jeden podpis?**

Ano. Přidejte každý podpis do kolekce vrácené metodou [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) před uložením. Během ověřování prozkoumejte každý podpis a potvrďte, že jsou přítomni všichni požadovaní podepisovatelé.

**Které formáty prezentací tyto operace podporují?**

Aspose.Slides podporuje operace s digitálními podpisy popsané zde pouze pro PPTX. Formáty PPT a OpenDocument nejsou tímto API pracovním postupem podporovány.

**Mohu odstranit podpis bez ovlivnění snímků?**

Ano. Můžete odstranit jeden podpis nebo vyprázdnit celou kolekci a potom uložit prezentaci. Obsah snímků zůstává dostupný, ale uložený soubor již neobsahuje důkaz o odstraněném podpisu.