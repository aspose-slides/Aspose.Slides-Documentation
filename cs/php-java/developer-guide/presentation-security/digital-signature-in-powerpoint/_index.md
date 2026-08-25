---
title: Přidání digitálních podpisů do prezentací v PHP
linktitle: Digitální podpis
type: docs
weight: 10
url: /cs/php-java/digital-signature-in-powerpoint/
keywords:
- digitální podpis
- digitální certifikát
- certifikační autorita
- certifikát PFX
- PKCS#12
- ověřit podpis
- PowerPoint
- PPTX
- zabezpečení prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak podepsat existující PPTX prezentace pomocí PFX certifikátů a používat Aspose.Slides pro PHP prostřednictvím Javy k ověření nebo odstranění digitálních podpisů."
---
## **Přehled**

Digitální podpis pomáhá příjemci určit, kdo prezentaci podepsal a zda se podepsaný obsah změnil. Zde jsou důležité tři související bezpečnostní koncepty:

- **digitální certifikát** je elektronický doklad, který spojuje identitu s veřejným klíčem. Důvěryhodná certifikační autorita (CA) může certifikát vystavit, nebo organizace může použít samopodepsaný certifikát pro interní pracovní postupy.
- **digitální podpis** je vytvořen z obsahu prezentace a soukromého klíče držitele certifikátu. Veřejný klíč certifikátu lze potom použít k ověření podpisu. Podpis poskytuje důkaz o původu a integritě; nešifruje prezentaci.
- **Ochrana heslem** řídí, zda uživatel může otevřít nebo upravit prezentaci. Je oddělena od digitálního podepisování a je popsána v [Password-Protected Presentations](/slides/cs/php-java/password-protected-presentation/).

PowerPoint poskytuje příkaz **Přidat digitální podpis** pod **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation menu with Přidat digitální podpis highlighted](add-digital-signature-in-powerpoint.png)

Po otevření podepsané prezentace může PowerPoint zobrazit upozornění o stavu podpisu.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides vystavuje podpisy prostřednictvím [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getDigitalSignatures), který vrací [DigitalSignatureCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/digitalsignaturecollection/), jejíž položky jsou reprezentovány objekty [DigitalSignature](https://reference.aspose.com/slides/cs/php-java/aspose.slides/digitalsignature/). Prezentace může obsahovat více podpisů.

## **Pochopení PFX certifikátů a hesel**

Soubor PFX, také známý jako soubor PKCS#12 a obvykle označovaný příponou `.pfx` nebo `.p12`, může obsahovat certifikát X.509, jeho soukromý klíč a řetězec certifikátů. Soukromý klíč umožňuje držiteli vytvořit podpis. Certifikát bez přístupného soukromého klíče nelze použít k podepsání prezentace.

Heslo PFX chrání balíček certifikátu a soukromý klíč. Není to heslo pro otevření nebo úpravu prezentace. Neskladujte soubory PFX ani jejich hesla v systému správy zdrojového kódu. Ve výrobě omezte přístup k souboru certifikátu a získávejte jeho heslo z úložiště tajemství nebo jiného chráněného konfiguračního zdroje. Níže uvedené příklady používají proměnnou prostředí pouze proto, aby se heslo nevkládalo přímo do kódu.

## **Přidat digitální podpis k prezentaci**

Pro podepsání skutečného pracovního postupu načtěte existující soubor PPTX, vytvořte [DigitalSignature](https://reference.aspose.com/slides/cs/php-java/aspose.slides/digitalsignature/) z PFX certifikátu a jeho hesla, přidejte podpis do kolekce prezentace a uložte do souboru PPTX.

```php
$certificatePassword = getenv("PFX_PASSWORD");
if ($certificatePassword === false || $certificatePassword === "") {
    throw new RuntimeException("Set the PFX_PASSWORD environment variable.");
}

$presentation = new Presentation("InputPresentation.pptx");
try {
    $signature = new DigitalSignature("signing-certificate.pfx", $certificatePassword);
    $signature->setComments("Approved for release.");

    $presentation->getDigitalSignatures()->add($signature);
    $presentation->save("InputPresentation-signed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Uložení výsledku pod novým názvem zachová neoznačený zdrojový soubor. Hodnota nastavená pomocí [DigitalSignature::setComments](https://reference.aspose.com/slides/cs/php-java/aspose.slides/digitalsignature/setcomments/) popisuje účel podpisu; nejde o bezpečnostní kontrolu.

## **Ověřit digitální podpisy**

Při načtení podepsaného souboru PPTX prozkoumejte každou položku vrácenou metodou [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getDigitalSignatures). Metoda [DigitalSignature::isValid](https://reference.aspose.com/slides/cs/php-java/aspose.slides/digitalsignature/isvalid/) udává, zda je vložený podpis platný pro aktuální obsah prezentace.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $signatures = $presentation->getDigitalSignatures();
    $signatureCount = java_values($signatures->size());

    if ($signatureCount === 0) {
        echo "The presentation does not contain digital signatures." . PHP_EOL;
    } else {
        $allSignaturesAreValid = true;
        $signTimeFormat = new Java("java.text.SimpleDateFormat", "yyyy-MM-dd HH:mm:ss");
        $certificateFactoryClass = new JavaClass("java.security.cert.CertificateFactory");
        $certificateFactory = $certificateFactoryClass->getInstance("X.509");

        for ($index = 0; $index < $signatureCount; $index++) {
            $signature = $signatures->get_Item($index);
            $signatureIsValid = java_values($signature->isValid());
            $signatureStatus = $signatureIsValid ? "VALID" : "INVALID";
            $formattedSignTime = java_values($signTimeFormat->format($signature->getSignTime()));

            $certificateData = $signature->getCertificate();
            $certificateStream = new Java("java.io.ByteArrayInputStream", $certificateData);
            try {
                $certificate = $certificateFactory->generateCertificate($certificateStream);
                $signerName = java_values($certificate->getSubjectX500Principal()->getName());
            } finally {
                $certificateStream->close();
            }

            echo $signerName . ", " . $formattedSignTime . " -- " . $signatureStatus . PHP_EOL;

            $allSignaturesAreValid = $allSignaturesAreValid && $signatureIsValid;
        }

        if ($allSignaturesAreValid) {
            echo "All embedded signatures are valid for the current presentation." . PHP_EOL;
        } else {
            echo "At least one embedded signature is invalid." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Neplatný výsledek obvykle znamená, že se po podepsání změnil obsah prezentace nebo data podpisu, nebo že soubor je poškozený. Odstranění všech podpisů vytvoří neoznačenou prezentaci, takže kontrola pouze platnosti položek není dostatečná: citlivý bezpečnostní proces musí také ověřit, že je přítomen očekávaný počet podpisů a očekávané identity podepisujících.

Tento výsledek platnosti by neměl být považován za kompletní rozhodnutí o důvěře certifikátu. V závislosti na vaší bezpečnostní politice může aplikace potřebovat také sestavit a ověřit řetězec certifikátů X.509, zkontrolovat data platnosti a stav odvolání certifikátu, potvrdit očekávaný subjekt nebo otisk, ověřit použití klíče a vyhodnotit důvěryhodný časový razítko. Hodnota z [DigitalSignature::getSignTime](https://reference.aspose.com/slides/cs/php-java/aspose.slides/digitalsignature/getsigntime/) sama o sobě není důkazem od důvěryhodné autority časových razítek.

## **Odstranit digitální podpisy**

Odstranění podpisů mění bezpečnostní stav prezentace. Následující příklad načte podepsaný soubor PPTX, odstraní všechny podpisy pomocí [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/cs/php-java/aspose.slides/digitalsignaturecollection/clear/), a uloží neoznačenou kopii.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pro odstranění pouze jednoho podpisu zavolejte [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/digitalsignaturecollection/removeat/) s jeho indexem začínajícím od nuly. Uložte do nového souboru, pokud přepisování podepsaného originálu není explicitní součástí vašeho pracovního postupu.

## **Úpravy a úvahy o formátu**

- Podpis neznamená, že se prezentace stane jen pro čtení. Uživatelé i aplikace mohou soubor stále editovat, ale změny podepsaného obsahu obvykle neplatný existující podpis.
- Dokončete všechny zamýšlené úpravy před podepsáním. Pokud je nutné prezentaci změnit, uložte revidovanou verzi a podepište tuto revizi znovu.
- Zachovejte finální výstup ve formátu PPTX. Převod podepsané prezentace do jiného formátu nepřenáší původní PPTX podpis jako platný podpis pro převedený soubor.
- Považujte soukromý klíč certifikátu za citlivý. Kdokoli, kdo získá soukromý klíč a jeho heslo, může vytvářet podpisy, které se jeví jako pocházející od držitele tohoto certifikátu.
- Uchovávejte neoznačený zdroj nebo další kontrolovanou kopii, pokud to vyžaduje vaše politika archivace dokumentů.

## **Často kladené otázky**

**Šifruje digitální podpis prezentaci?**

Ne. Digitální podpis poskytuje důkaz o původu a integritě, ale obsah prezentace zůstává čitelný, pokud není použita samostatná šifrování. Použijte [password protection](/slides/cs/php-java/password-protected-presentation/), když je nutné omezit přístup k obsahu.

**Je heslo PFX stejné jako heslo prezentace?**

Ne. Heslo PFX odemyká soukromý klíč uložený v balíčku certifikátu. Neřídí, kdo může otevřít nebo upravit soubor PPTX.

**Mohu použít samopodepsaný certifikát?**

Technicky lze samopodepsaný certifikát použít, pokud obsahuje přístupný soukromý klíč. Příjemci ho však nebudou automaticky důvěřovat, pokud není výslovně přidán do jejich důvěryhodného prostředí. Ve veřejných nebo meziorganizačních pracovních postupech se běžně používá certifikát vydaný důvěryhodnou CA.

**Co způsobuje neplatnost podpisu?**

Změna podepsaného obsahu prezentace nebo dat podpisu po podepsání může podpis neplatnit. Poškození souboru může také způsobit selhání ověření. Pokud jsou všechny podpisy odstraněny, prezentace je neoznačená, nikoli soubor s neplatným podpisem.

**Znamená platný podpis, že mám důvěřovat podepisujícímu?**

Ne samostatně. Integrita podpisu a důvěra k podepisujícímu jsou oddělená rozhodnutí. Produkční validační politika by také měla kontrolovat řetězec certifikátů, období platnosti, stav odvolání, očekávanou identitu, použití klíče a případné požadavky na důvěryhodné časové razítko.

**Co se stane, když certifikát vyprší?**

Vypršení certifikátu nemění bajty prezentace, ale ovlivňuje hodnocení důvěryhodnosti certifikátu. Zda podpis zůstane přijatelný, závisí na vaší politice a na tom, zda důvěryhodné časové razítko dokazuje, že podepsání proběhlo během platnosti certifikátu. Nespoléhejte se jen na zobrazený čas podpisu jako na důvěryhodné časové razítko.

**Může být podepsaná prezentace stále editována?**

Ano. Podepsání nezamyká soubor. Úprava podepsaného obsahu obvykle způsobí neplatnost existujícího podpisu, takže dokončete prezentaci nejprve a pak podepište finální revizi.

**Může prezentace obsahovat více než jeden podpis?**

Ano. Přidejte každý podpis do kolekce vrácené metodou [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getDigitalSignatures) před uložením. Během ověřování prozkoumejte každý podpis a potvrďte, že jsou přítomni všichni požadovaní podepisující.

**Které formáty prezentací podporují tyto operace?**

Aspose.Slides podporuje operace s digitálním podpisem popsané zde pouze pro PPTX. Formáty PPT a OpenDocument nejsou tímto API pracovním postupem podporovány.

**Mohu odstranit podpis bez ovlivnění snímků?**

Ano. Můžete odstranit jeden podpis nebo vyprázdnit celou kolekci a poté uložit prezentaci. Obsah snímků zůstane zachován, ale uložený soubor již neobsahuje důkazy o odstraněném podpisu.