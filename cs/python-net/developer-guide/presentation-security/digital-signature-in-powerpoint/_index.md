---
title: Přidání digitálních podpisů do prezentací pomocí Pythonu
linktitle: Digitální podpis
type: docs
weight: 10
url: /cs/python-net/digital-signature-in-powerpoint/
keywords:
- digitální podpis
- digitální certifikát
- certifikační autorita
- PFX certifikát
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak digitálně podepisovat soubory PowerPoint a OpenDocument pomocí Aspose.Slides pro Python v .NET. Zabezpečte své snímky během několika sekund s jasnými ukázkami kódu."
---
## **Úvod**

**Digitální certifikát** se používá k vytvoření prezentace PowerPoint chráněné heslem, označené jako vytvořenou konkrétní organizací nebo osobou. Digitální certifikát lze získat kontaktováním oprávněné organizace – certifikační autority. Po instalaci digitálního certifikátu do systému jej lze použít k přidání digitálního podpisu do prezentace přes Soubor → Info → Ochraňovat prezentaci:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Prezentace může obsahovat více než jeden digitální podpis. Po přidání digitálního podpisu do prezentace se v PowerPointu zobrazí speciální zpráva:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Pro podepisování prezentace nebo kontrolu pravosti podpisů prezentace poskytuje **Aspose.Slides API** třídu [**DigitalSignature**](https://reference.aspose.com/slides/cs/python-net/aspose.slides/digitalsignature/), třídu [**DigitalSignatureCollection**](https://reference.aspose.com/slides/cs/python-net/aspose.slides/DigitalSignatureCollection/) a vlastnost [**Presentation.digital_signatures**](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/digital_signatures/). V současné době jsou digitální podpisy podporovány pouze pro formát PPTX.

## **Přidání digitálního podpisu z PFX certifikátu**

Níže uvedený ukázkový kód demonstruje, jak přidat digitální podpis z PFX certifikátu:

1. Otevřete soubor PFX a předáte heslo PFX objektu [**DigitalSignature**](https://reference.aspose.com/slides/cs/python-net/aspose.slides/digitalsignature/).
1. Přidejte vytvořený podpis do objektu prezentace.

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    # Vytvořte objekt DigitalSignature s PFX souborem a heslem PFX 
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # Poznámka k novému digitálnímu podpisu
    signature.comments = "Aspose.Slides digital signing test."

    # Přidejte digitální podpis do prezentace
    pres.digital_signatures.add(signature)

    # uložit prezentaci
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```



Nyní je možné zkontrolovat, zda byla prezentace digitálně podepsána a nebyla upravena:

```py
# Otevřít prezentaci
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signatures used to sign the presentation: ")
        # Zkontrolovat, zda jsou všechny digitální podpisy platné
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("Presentation is genuine, all signatures are valid.")
        else:
            print("Presentation has been modified since signing.")
```

## **Často kladené otázky**

**Mohu odstranit existující podpisy ze souboru?**

Ano. Kolekce digitálních podpisů podporuje [odstranění jednotlivých položek](https://reference.aspose.com/slides/cs/python-net/aspose.slides/digitalsignaturecollection/remove_at/) i [vymazání celé kolekce](https://reference.aspose.com/slides/cs/python-net/aspose.slides/digitalsignaturecollection/clear/); po uložení souboru nebude v prezentaci žádný podpis.

**Stane se soubor po podepsání „pouze pro čtení“?**

Ne. Podpis zachovává integritu a autorství, ale neblokuje úpravy. Pro omezení úprav jej můžete kombinovat s ["Pouze pro čtení" nebo heslem](/slides/cs/python-net/password-protected-presentation/).

**Zobrazí se podpis správně v různých verzích PowerPointu?**

Podpis je vytvořen pro kontejner OOXML (PPTX). Moderní verze PowerPointu, které podporují OOXML podpisy, zobrazují stav takových podpisů správně.