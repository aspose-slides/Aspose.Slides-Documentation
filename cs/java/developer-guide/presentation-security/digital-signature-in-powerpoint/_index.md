---
title: Přidat digitální podpisy do prezentací v Java
linktitle: Digitální podpis
type: docs
weight: 10
url: /cs/java/digital-signature-in-powerpoint/
keywords:
- digitální podpis
- digitální certifikát
- certifikační autorita
- PFX certifikát
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Naučte se, jak digitálně podepisovat soubory PowerPoint a OpenDocument pomocí Aspose.Slides pro Java. Zabezpečte své snímky během několika sekund s jasnými ukázkami kódu."
---
## **Úvod**

**Digitální certifikát** se používá k vytvoření prezentace PowerPoint chráněné heslem, označené jako vytvořenou konkrétní organizací nebo osobou. Digitální certifikát lze získat kontaktováním oprávněné organizace – certifikační autority. Po instalaci digitálního certifikátu do systému jej lze použít k přidání digitálního podpisu do prezentace prostřednictvím Soubor → Informace → Zabezpečit prezentaci:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Prezentace může obsahovat více než jeden digitální podpis. Po přidání digitálního podpisu do prezentace se v PowerPointu zobrazí speciální zpráva:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Pro podepsání prezentace nebo ověření pravosti podpisů v prezentaci poskytuje Aspose.Slides API rozhraní [**IDigitalSignature**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IDigitalSignature), rozhraní [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IDigitalSignatureCollection) a metodu [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPresentation#getDigitalSignatures--). V současné době jsou digitální podpisy podporovány pouze pro formát PPTX.
## **Přidání digitálního podpisu z PFX certifikátu**
Níže uvedený ukázkový kód demonstruje, jak přidat digitální podpis z PFX certifikátu:

1. Otevřete soubor PFX a předáte heslo PFX objektu [**DigitalSignature**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/DigitalSignature).
1. Přidejte vytvořený podpis do objektu prezentace.

```java
// Otevření souboru prezentace
Presentation pres = new Presentation();
try {
    // Vytvořte objekt DigitalSignature s PFX souborem a PFX heslem
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // Komentář nového digitálního podpisu
    signature.setComments("Aspose.Slides digital signing test.");

    // Přidání digitálního podpisu do prezentace
    pres.getDigitalSignatures().add(signature);

    // Uložení prezentace
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Nyní je možné zkontrolovat, zda byla prezentace digitálně podepsána a nebyla upravena:

```java
// Otevření prezentace
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signatures used to sign the presentation: ");

        // Zkontrolovat, zda jsou všechny digitální podpisy platné
        for (IDigitalSignature signature : pres.getDigitalSignatures())
        {
            System.out.println(signature.getComments() + ", "
                    + signature.getSignTime().toString() + " -- " + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }

        if (allSignaturesAreValid)
            System.out.println("Presentation is genuine, all signatures are valid.");
        else
            System.out.println("Presentation has been modified since signing.");
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Mohu odstranit existující podpisy ze souboru?**

Ano. Kolekce digitálních podpisů podporuje odstraňování jednotlivých položek a úplné vymazání; po uložení souboru nebude v prezentaci žádný podpis.

**Stane se soubor po podpisu „read-only“?**

Ne. Podpis zachovává integritu a autorství, ale neblokuje úpravy. Pro omezení úprav jej kombinujte s ["Read-only" or a password](/slides/cs/java/password-protected-presentation/).

**Zobrazí se podpis správně v různých verzích PowerPointu?**

Podpis je vytvořen pro kontejner OOXML (PPTX). Moderní verze PowerPointu, které podporují OOXML podpisy, zobrazují stav takových podpisů správně.