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
- PFX certifikát
- PKCS#12
- ověřit podpis
- PowerPoint
- PPTX
- zabezpečení prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak podepisovat existující PPTX prezentace pomocí PFX certifikátů a používat Aspose.Slides pro PHP přes Java k ověření nebo odstranění digitálních podpisů."
---
## **Přehled**

Digitální podpis pomáhá příjemci určit, kdo prezentaci podepsal a zda se podepsaný obsah změnil. Důležité jsou zde tři související bezpečnostní pojmy:

- **digitální certifikát** je elektronické oprávnění, které spojuje identitu s veřejným klíčem. Důvěryhodná certifikační autorita (CA) může certifikát vydat, nebo může organizace použít samopodepsaný certifikát pro interní pracovní postupy.
- **digitální podpis** je vytvořen z obsahu prezentace a soukromého klíče držitele certifikátu. Veřejný klíč certifikátu pak může být použit k ověření podpisu. Podpis poskytuje důkaz o původu a integritě; nešifruje prezentaci.
- **Ochrana heslem** řídí, zda uživatel může prezentaci otevřít nebo upravit. Je oddělena od digitálního podepisování a je popsána v [Password-Protected Presentations](/php-java/password-protected-presentation/).

PowerPoint poskytuje příkaz **Add a Digital Signature** pod **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

Po otevření podepsané prezentace může PowerPoint zobrazit oznámení o stavu podpisu.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides zpřístupňuje podpisy prostřednictvím [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getDigitalSignatures), který vrací [DigitalSignatureCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/digitalsignaturecollection/), jejíž položky jsou reprezentovány objekty [DigitalSignature](https://reference.aspose.com/slides/cs/php-java/aspose.slides/digitalsignature/). Prezentace může obsahovat více podpisů.

## **Pochopení PFX certifikátů a hesel**

Soubor PFX, také známý jako PKCS#12 soubor a běžně s příponou `.pfx` nebo `.p12`, může obsahovat certifikát X.509, jeho soukromý klíč a řetězec certifikátů. Soukromý klíč umožňuje držiteli vytvořit podpis. Certifikát bez přístupného soukromého klíče nelze použít k podepsání prezentace.

Heslo PFX chrání balíček certifikátu a soukromý klíč. Není to heslo pro otevření nebo úpravu prezentace. Nepřidávejte soubory PFX ani jejich hesla do správy verzí. Ve výrobě omezte přístup k souboru certifikátu a získávejte jeho heslo z úložiště tajemství nebo jiného chráněného konfiguračního zdroje. Níže uvedené příklady používají proměnnou prostředí jen proto, aby se heslo neukládalo přímo v kódu.

## **Přidání digitálního podpisu do prezentace**

Pro podepisování reálného pracovního postupu načtěte existující soubor PPTX, vytvořte [DigitalSignature](https://reference.aspose.com/slides/cs/php-java/aspose.slides/digitalsignature/) z PFX certifikátu a jeho hesla, přidejte podpis do kolekce prezentace a uložte do souboru PPTX.

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

## **Ověření digitálních podpisů**

Když načtete podepsaný soubor PPTX, prohlédněte každou položku vrácenou metodou [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getDigitalSignatures). Metoda [DigitalSignature::isValid](https://reference.aspose.com/slides/cs/php-java/aspose.slides/digitalsignature/isvalid/) udává, zda je vložený podpis platný pro aktuální obsah prezentace.

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

Neplatný výsledek často znamená, že se po podpisu změnil obsah prezentace nebo data podpisu, nebo že je soubor poškozen. Odstranění všech podpisů vytvoří neoznačenou prezentaci, takže kontrola pouze platnosti položek není dostačující: bezpečnostně citlivý pracovní postup musí také ověřit, že je přítomen očekávaný počet podpisů a očekávané identity podepisujících.

Tento výsledek platnosti by neměl být považován za úplné rozhodnutí o důvěře certifikátu. V závislosti na vaší bezpečnostní politice může vaše aplikace také potřebovat vytvořit a ověřit řetězec certifikátů X.509, zkontrolovat data platnosti certifikátu a stav odvolání, potvrdit očekávaný subjekt nebo otisk, ověřit použití klíče a vyhodnotit důvěryhodný časový razítko. Hodnota [DigitalSignature::getSignTime](https://reference.aspose.com/slides/cs/php-java/aspose.slides/digitalsignature/getsigntime/) sama o sobě není důkazem od důvěryhodné časové autority.

## **Odstranění digitálních podpisů**

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

Pro odstranění pouze jednoho podpisu zavolejte [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/digitalsignaturecollection/removeat/) s jeho nulovým indexem. Uložte do nového souboru, pokud nepřepisujete původní podepsaný soubor jako součást vašeho pracovního postupu.

## **Úpravy a úvahy o formátu**

- Podpis neznamená, že je prezentace jen ke čtení. Uživatelé a aplikace mohou soubor nadále upravovat, ale změny podepsaného obsahu obvykle neplatný existující podpis.
- Proveďte všechny zamýšlené úpravy před podpisem. Pokud je potřeba prezentaci změnit, uložte upravenou verzi a podepište ji znovu.
- Uchovávejte konečný výstup ve formátu PPTX. Převod podepsané prezentace do jiného formátu nepřenáší původní PPTX podpis jako platný podpis pro převedený soubor.
- Považujte soukromý klíč certifikátu za citlivý. Kdokoli, kdo získá soukromý klíč a jeho heslo, může vytvořit podpisy, které se jeví jako pocházející od držitele tohoto certifikátu.
- Uchovejte neoznačený zdroj nebo další kontrolovanou kopii, pokud to vyžaduje vaše politika archivace dokumentů.

## **Časté dotazy**

**Zda digitální podpis šifruje prezentaci?**

Ne. Digitální podpis poskytuje důkaz o původu a integritě, ale obsah prezentace zůstává čitelný, pokud není použita samostatná šifrování. Použijte [password protection](/php-java/password-protected-presentation/), když je nutné omezit přístup k obsahu.

**Je heslo PFX stejné jako heslo prezentace?**

Ne. Heslo PFX odemyká soukromý klíč uložený v balíčku certifikátu. Nekontroluje, kdo může otevřít nebo upravit soubor PPTX.

**Mohu použít samopodepsaný certifikát?**

Technicky lze použít samopodepsaný certifikát, pokud obsahuje přístupný soukromý klíč. Příjemci jej automaticky nedůvěřují, pokud není explicitně přidán do jejich důvěryhodného prostředí. Ve veřejných nebo mezi‑organizacíních pracovních postupech se obvykle používá certifikát vydaný důvěryhodnou CA.

**Co činí podpis neplatným?**

Změna podepsaného obsahu prezentace nebo dat podpisu po podpisu může podpis neplatný učinit. Poškození souboru může také způsobit neúspěšné ověření. Pokud jsou všechny podpisy odstraněny, prezentace je neoznačená, nikoli soubor s neplatným podpisem.

**Znamená platný podpis, že mám důvěřovat podepisujícímu?**

Ne samostatně. Integrita podpisu a důvěra k podepisujícímu jsou samostatná rozhodnutí. Produkční validační politika by měla také kontrolovat řetězec certifikátů, období platnosti, stav odvolání, očekávanou identitu, použití klíče a případné požadavky na důvěryhodné časové razítko.

**Co se stane, když certifikát vyprší?**

Vypršení certifikátu nemění bajty prezentace, ale ovlivňuje hodnocení důvěry certifikátu. Zda podpis zůstane přijatelné, závisí na vaší politice a na tom, zda důvěryhodné časové razítko dokáže, že podpis byl vytvořen během platnosti certifikátu. Nespoléhejte se pouze na zobrazený čas podpisu jako na důvěryhodné razítko.

**Může být podepsaná prezentace stále upravována?**

Ano. Podepsání nezablokuje soubor. Úprava podepsaného obsahu obecně způsobí, že existující podpis bude neplatný, proto dokončete prezentaci a podepište finální revizi.

**Může prezentace obsahovat více než jeden podpis?**

Ano. Přidejte každý podpis do kolekce vrácené metodou [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getDigitalSignatures) před uložením. Při validaci prohlédněte každý podpis a potvrďte, že jsou přítomni všichni požadovaní podepisující.

**Které formáty prezentací podporují tyto operace?**

Aspose.Slides podporuje operace s digitálními podpisy popsané zde pouze pro PPTX. Formáty PPT a OpenDocument prezentace nejsou tímto API pracovním postupem podporovány.

**Mohu odstranit podpis bez ovlivnění snímků?**

Ano. Můžete odstranit jeden podpis nebo vyprázdnit celou kolekci a poté prezentaci uložit. Obsah snímků zůstane zachován, ale uložený soubor již neobsahuje důkaz o odstraněném podpisu.