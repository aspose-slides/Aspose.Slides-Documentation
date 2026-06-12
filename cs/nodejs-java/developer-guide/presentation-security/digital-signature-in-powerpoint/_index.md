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
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se, jak digitálně podepisovat soubory PowerPoint a OpenDocument pomocí Aspose.Slides pro Node.js přes Java. Zabezpečte své snímky během několika sekund s přehlednými ukázkami kódu."
---
## **Úvod**

**Digitální certifikát** se používá k vytvoření prezentace PowerPoint chráněné heslem, označené jako vytvořenou konkrétní organizací nebo osobou. Digitální certifikát lze získat kontaktováním oprávněné organizace – certifikační autority. Po nainstalování digitálního certifikátu do systému jej lze použít k přidání digitálního podpisu do prezentace přes Soubor → Informace → Ochrana prezentace:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Prezentace může obsahovat více než jeden digitální podpis. Po přidání digitálního podpisu do prezentace se v PowerPointu zobrazí speciální zpráva:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Pro podepsání prezentace nebo kontrolu pravosti podpisů prezentace poskytuje **Aspose.Slides API** třídu [**DigitalSignature**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/DigitalSignature), třídu [**DigitalSignatureCollection**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/DigitalSignatureCollection) a metodu [**Presentation.getDigitalSignatures**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#getDigitalSignatures--). V současné době jsou digitální podpisy podporovány pouze pro formát PPTX.

## **Přidání digitálního podpisu z PFX certifikátu**
Níže uvedený ukázkový kód demonstruje, jak přidat digitální podpis z PFX certifikátu:

1. Otevřete soubor PFX a předjte heslo PFX objektu [**DigitalSignature**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/DigitalSignature).
2. Přidejte vytvořený podpis do objektu prezentace.

```javascript
// Otevírání souboru prezentace
var pres = new aspose.slides.Presentation();
try {
    // Vytvořit objekt DigitalSignature s PFX souborem a PFX heslem
    var signature = new aspose.slides.DigitalSignature("testsignature1.pfx", "testpass1");
    // Komentář k novému digitálnímu podpisu
    signature.setComments("Aspose.Slides digital signing test.");
    // Přidat digitální podpis do prezentace
    pres.getDigitalSignatures().add(signature);
    // Uložit prezentaci
    pres.save("SomePresentationSigned.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Nyní je možné zkontrolovat, zda byla prezentace digitálně podepsána a nebyla upravena:

```javascript
// Open presentation
var pres = new aspose.slides.Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0) {
        var allSignaturesAreValid = true;
        console.log("Signatures used to sign the presentation: ");
        // Check if all digital signatures are valid
        for (let i = 0; i < pres.getDigitalSignatures().size(); i++) {
        let signature = pres.getDigitalSignatures().get_Item(i);
            console.log((((signature.getComments() + ", ") + signature.getSignTime().toString()) + " -- ") + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }
        if (allSignaturesAreValid) {
            console.log("Presentation is genuine, all signatures are valid.");
        } else {
            console.log("Presentation has been modified since signing.");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Mohu odstranit existující podpisy ze souboru?**

Ano. Kolekce digitálních podpisů podporuje [odstranění jednotlivých položek](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) a [úplné vymazání](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/digitalsignaturecollection/clear/); po uložení souboru nebude v prezentaci žádný podpis.

**Stane se soubor po podpisu „pouze pro čtení“?**

Ne. Podpis zachovává integritu a autorství, ale neblokuje úpravy. Pro omezení úprav jej kombinujte s ["Read-only" or a password](/slides/cs/nodejs-java/password-protected-presentation/).

**Zobrazí se podpis správně v různých verzích PowerPointu?**

Podpis je vytvořen pro kontejner OOXML (PPTX). Moderní verze PowerPointu, které podporují OOXML podpisy, správně zobrazují stav takových podpisů.