---
title: Přidat digitální podpisy do prezentací v PHP
linktitle: Digitální podpis
type: docs
weight: 10
url: /cs/php-java/digital-signature-in-powerpoint/
keywords:
- digitální podpis
- digitální certifikát
- certifikační autorita
- PFX certifikát
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak digitálně podepsat soubory PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP přes Java. Zabezpečte své snímky během několika sekund s jasnými ukázkami kódu."
---
## **Úvod**

**Digitální certifikát** se používá k vytvoření prezentace PowerPoint chráněné heslem, označené jako vytvořená konkrétní organizací nebo osobou. Digitální certifikát lze získat kontaktováním autorizované organizace – certifikační autority. Po instalaci digitálního certifikátu do systému jej lze použít k přidání digitálního podpisu do prezentace přes Soubor → Informace → Chránit prezentaci:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Prezentace může obsahovat více než jeden digitální podpis. Po přidání digitálního podpisu do prezentace se v PowerPointu zobrazí speciální zpráva:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

K podepsání prezentace nebo ověření pravosti podpisů prezentace poskytuje **Aspose.Slides API** třídu [**DigitalSignature**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/DigitalSignature), třídu [**DigitalSignatureCollection**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/DigitalSignatureCollection) a metodu [**Presentation::getDigitalSignatures**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation/#getDigitalSignatures). V současné době jsou digitální podpisy podporovány pouze pro formát PPTX.

## **Přidání digitálního podpisu z PFX certifikátu**

Níže uvedený ukázkový kód demonstruje, jak přidat digitální podpis z PFX certifikátu:

1. Otevřete soubor PFX a předáte heslo PFX objektu [**DigitalSignature**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/DigitalSignature).
1. Přidejte vytvořený podpis do objektu prezentace.

```php
  # Otevírání souboru prezentace
  $pres = new Presentation();
  try {
    # Vytvořit objekt DigitalSignature s PFX souborem a PFX heslem
    $signature = new DigitalSignature("testsignature1.pfx", "testpass1");
    # Komentář k novému digitálnímu podpisu
    $signature->setComments("Aspose.Slides digital signing test.");
    # Přidat digitální podpis do prezentace
    $pres->getDigitalSignatures()->add($signature);
    # Uložit prezentaci
    $pres->save("SomePresentationSigned.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

Nyní je možné zkontrolovat, zda byla prezentace digitálně podepsána a nebyla upravena:

```php
  # Otevřít prezentaci
  $pres = new Presentation("SomePresentationSigned.pptx");
  try {
    if (java_values($pres->getDigitalSignatures()->size()) > 0) {
      $allSignaturesAreValid = true;
      echo("Signatures used to sign the presentation: ");
      # Zkontrolovat, zda jsou všechny digitální podpisy platné
      foreach($pres->getDigitalSignatures() as $signature) {
        echo($signature->getComments() . ", " . $signature->getSignTime()->toString() . " -- " . $signature->isValid() ? "VALID" : "INVALID");
        $allSignaturesAreValid &= $signature->isValid();
      }
      if ($allSignaturesAreValid) {
        echo("Presentation is genuine, all signatures are valid.");
      } else {
        echo("Presentation has been modified since signing.");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Mohu odstranit existující podpisy ze souboru?**

Ano. Kolekce digitálních podpisů podporuje [removing individual items](https://reference.aspose.com/slides/cs/php-java/aspose.slides/digitalsignaturecollection/removeat/) a [clearing it entirely](https://reference.aspose.com/slides/cs/php-java/aspose.slides/digitalsignaturecollection/clear/); po uložení souboru nebude v prezentaci žádný podpis.

**Stane se soubor po podpisu „read-only“?**

Ne. Podpis zachovává integritu a autorství, ale neblokuje úpravy. Pro omezení úprav jej kombinujte s ["Read-only" nebo heslem](/slides/cs/php-java/password-protected-presentation/).

**Zobrazí se podpis správně v různých verzích PowerPointu?**

Podpis je vytvořen pro kontejner OOXML (PPTX). Moderní verze PowerPointu, které podporují OOXML podpisy, zobrazí stav takových podpisů správně.