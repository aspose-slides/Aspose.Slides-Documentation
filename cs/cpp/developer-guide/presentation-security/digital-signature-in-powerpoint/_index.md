---
title: Přidání digitálních podpisů do prezentací v C++
linktitle: Digitální podpis
type: docs
weight: 10
url: /cs/cpp/digital-signature-in-powerpoint/
keywords:
- digitální podpis
- digitální certifikát
- certifikační autorita
- PFX certifikát
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak digitálně podepsat soubory PowerPoint a OpenDocument pomocí Aspose.Slides pro C++. Zabezpečte své snímky během několika sekund s jasnými ukázkami kódu."
---
## **Úvod**

**Digitální certifikát** se používá k vytvoření prezentace PowerPoint chráněné heslem, označené jako vytvořená konkrétní organizací nebo osobou. Digitální certifikát lze získat kontaktováním oprávněné organizace – certifikační autority. Po instalaci digitálního certifikátu do systému jej lze použít k přidání digitálního podpisu do prezentace pomocí Soubor → Informace → Chránit prezentaci:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Prezentace může obsahovat více než jeden digitální podpis. Po přidání digitálního podpisu do prezentace se v PowerPointu zobrazí speciální zpráva:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Pro podepsání prezentace nebo kontrolu pravosti podpisů prezentace poskytuje **Aspose.Slides API** **IDigitalSignature** (https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_digital_signature) rozhraní, **IDigitalSignatureCollection** (https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_digital_signature_collection) rozhraní a **IPresentation.DigitalSignatures** (https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1) metodu. V současné době jsou digitální podpisy podporovány pouze pro formát PPTX.

## **Přidání digitálního podpisu z PFX certifikátu**

Níže uvedený ukázkový kód demonstruje, jak přidat digitální podpis z PFX certifikátu:

1. Otevřete soubor PFX a předávejte heslo PFX do objektu [**DigitalSignature**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.digital_signature) objektu.
2. Přidejte vytvořený podpis do objektu prezentace.

``` cpp
auto pres = System::MakeObject<Presentation>();

// Vytvořte objekt DigitalSignature s PFX souborem a PFX heslem 
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// Poznámka k novému digitálnímu podpisu
signature->set_Comments(u"Aspose.Slides digital signing test.");

// Přidejte digitální podpis do prezentace
pres->get_DigitalSignatures()->Add(signature);

// Uložte prezentaci
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```

Nyní je možné zkontrolovat, zda byla prezentace digitálně podepsána a nebyla změněna:

``` cpp
// Otevřete prezentaci
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"Signatures used to sign the presentation: ");

    // Zkontrolujte, zda jsou všechny digitální podpisy platné
    for (auto signature : pres->get_DigitalSignatures())
    {
        Console::WriteLine(signature->get_Certificate()->get_SubjectName()->get_Name() 
            + u", " 
            + signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm") 
            + u" -- " 
            + (signature->get_IsValid() ? System::String(u"VALID") : System::String(u"INVALID")));
        allSignaturesAreValid &= signature->get_IsValid();
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"Presentation is genuine, all signatures are valid.");
    }
    else
    {
        Console::WriteLine(u"Presentation has been modified since signing.");
    }
}
```

## **Často kladené otázky**

**Mohou být z souboru odstraněny existující podpisy?**

Ano. Kolekce digitálních podpisů podporuje [odstranění jednotlivých položek](https://reference.aspose.com/slides/cs/cpp/aspose.slides/digitalsignaturecollection/removeat/) a [úplné vymazání](https://reference.aspose.com/slides/cs/cpp/aspose.slides/digitalsignaturecollection/clear/); po uložení souboru nebude v prezentaci žádný podpis.

**Stane se soubor po podepsání „pouze pro čtení“?**

Ne. Podpis zachovává integritu a autorství, ale neblokuje úpravy. Pro omezení úprav kombinujte jej s ["Pouze pro čtení" nebo heslo](/slides/cs/cpp/password-protected-presentation/).

**Zobrazí se podpis správně v různých verzích PowerPointu?**

Podpis je vytvořen pro kontejner OOXML (PPTX). Moderní verze PowerPointu, které podporují OOXML podpisy, zobrazují stav takových podpisů správně.