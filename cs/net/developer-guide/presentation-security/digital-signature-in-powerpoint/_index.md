---
title: Přidání digitálních podpisů do prezentací v .NET
linktitle: Digitální podpis
type: docs
weight: 10
url: /cs/net/digital-signature-in-powerpoint/
keywords:
- digitální podpis
- digitální certifikát
- certifikační autorita
- PFX certifikát
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Zjistěte, jak digitálně podepsat soubory PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET. Zabezpečte své snímky během několika sekund s jasnými ukázkami kódu."
---
## **Úvod**

**Digitální certifikát** se používá k vytvoření prezentace PowerPoint chráněné heslem, označené jako vytvořenou konkrétní organizací nebo osobou. Digitální certifikát lze získat kontaktováním oprávněné organizace – certifikační autority. Po instalaci digitálního certifikátu do systému jej lze použít k přidání digitálního podpisu do prezentace přes Soubor -> Informace -> Chrání prezentaci:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Prezentace může obsahovat více než jeden digitální podpis. Po přidání digitálního podpisu do prezentace se v PowerPointu zobrazí speciální zpráva:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Pro podepsání prezentace nebo ověření pravosti podpisů prezentace poskytuje **Aspose.Slides API** rozhraní [**IDigitalSignature**](https://reference.aspose.com/slides/cs/net/aspose.slides/idigitalsignature), [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/cs/net/aspose.slides/IDigitalSignatureCollection) a [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/properties/digitalsignatures) vlastnost. V současné době jsou digitální podpisy podporovány pouze pro formát PPTX.

## **Přidání digitálního podpisu z PFX certifikátu**

Ukázkový kód níže ukazuje, jak přidat digitální podpis z PFX certifikátu:

1. Otevřete soubor PFX a předávejte heslo PFX do objektu [**DigitalSignature**](https://reference.aspose.com/slides/cs/net/aspose.slides/digitalsignature).
1. Přidejte vytvořený podpis do objektu prezentace.

```c#
using (Presentation pres = new Presentation())
{
    // Vytvořte objekt DigitalSignature s PFX souborem a heslem PFX 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // Komentář nového digitálního podpisu
    signature.Comments = "Aspose.Slides digital signing test.";

    // Přidejte digitální podpis do prezentace
    pres.DigitalSignatures.Add(signature);

    // Uložte prezentaci
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```

Nyní je možné zkontrolovat, zda byla prezentace digitálně podepsána a nebyla upravena:

```c#
 // Otevřít prezentaci
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("Signatures used to sign the presentation: ");

        // Zkontrolujte, zda jsou všechny digitální podpisy platné
        foreach (DigitalSignature signature in pres.DigitalSignatures)
        {
            Console.WriteLine(signature.Certificate.SubjectName.Name + ", "
                    + signature.SignTime.ToString("yyyy-MM-dd HH:mm") + " -- " + (signature.IsValid ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.IsValid;
        }

        if (allSignaturesAreValid)
            Console.WriteLine("Presentation is genuine, all signatures are valid.");
        else
            Console.WriteLine("Presentation has been modified since signing.");
    }
}
```

## **Často kladené otázky**

**Mohu z souboru odstranit existující podpisy?**

Ano. Kolekce digitálních podpisů podporuje [odstranění jednotlivých položek](https://reference.aspose.com/slides/cs/net/aspose.slides/digitalsignaturecollection/removeat/) a [vymazání celé kolekce](https://reference.aspose.com/slides/cs/net/aspose.slides/digitalsignaturecollection/clear/); po uložení souboru nebude v prezentaci žádný podpis.

**Stane se soubor po podpisu „pouze pro čtení“?**

Ne. Podpis zachovává integritu a autorství, ale neblokuje úpravy. Pro omezení úprav jej zkombinujte s [„Pouze pro čtení“ nebo heslem](/slides/cs/net/password-protected-presentation/).

**Zobrazí se podpis správně v různých verzích PowerPointu?**

Podpis je vytvořen pro kontejner OOXML (PPTX). Moderní verze PowerPointu, které podporují OOXML podpisy, zobrazují stav takových podpisů správně.