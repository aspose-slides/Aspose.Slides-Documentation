---
title: Přidání digitálních podpisů do prezentací v Javě
linktitle: Digitální podpis
type: docs
weight: 10
url: /cs/java/digital-signature-in-powerpoint/
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
- Java
- Aspose.Slides
description: "Naučte se, jak podepsat existující PPTX prezentace pomocí certifikátů PFX a použít Aspose.Slides pro Java k ověření nebo odstranění digitálních podpisů."
---
## **Přehled**

Digitální podpis pomáhá příjemci určit, kdo prezentaci podepsal a zda se podepsaný obsah změnil. Tři související bezpečnostní koncepty jsou zde důležité:

- **digitální certifikát** je elektronické oprávnění, které spojuje identitu s veřejným klíčem. Důvěryhodná certifikační autorita (CA) může certifikát vydat, nebo organizace může použít samopodepsaný certifikát pro interní pracovní toky.
- **digitální podpis** se vytváří z obsahu prezentace a soukromého klíče držitele certifikátu. Veřejný klíč certifikátu lze pak použít k ověření podpisu. Podpis poskytuje důkaz o původu a integritě; nešifruje prezentaci.
- **Ochrana heslem** řídí, zda uživatel může otevřít nebo upravit prezentaci. Je oddělena od digitálního podepisování a je popsána v [Password-Protected Presentations](/java/password-protected-presentation/).

PowerPoint poskytuje příkaz **Add a Digital Signature** v nabídce **File > Info > Protect Presentation**.

![Nabídka PowerPoint Protect Presentation s vyznačeným příkazem Add a Digital Signature](add-digital-signature-in-powerpoint.png)

Po otevření podepsané prezentace může PowerPoint zobrazit oznámení o stavu podpisu.

![Oznámení PowerPointu uvádějící, že prezentace obsahuje platné podpisy](digital-signature-status-in-powerpoint.png)

Aspose.Slides zpřístupňuje podpisy prostřednictvím [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentation/#getDigitalSignatures--), který vrací [IDigitalSignatureCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idigitalsignaturecollection/), jehož položky implementují [IDigitalSignature](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idigitalsignature/). Prezentace může obsahovat více podpisů.

## **Pochopení certifikátů PFX a hesel**

Soubor PFX, také známý jako soubor PKCS#12 a běžně s příponou `.pfx` nebo `.p12`, může obsahovat certifikát X.509, jeho soukromý klíč a řetězec certifikátů. Soukromý klíč umožňuje držiteli vytvořit podpis. Certifikát bez přístupného soukromého klíče nelze použít k podepsání prezentace.

Heslo PFX chrání balíček certifikátu a soukromý klíč. Není to **heslo** pro otevření nebo úpravu prezentace. Nesnažte se ukládat soubory PFX ani jejich hesla do správy zdrojového kódu. Ve výrobním prostředí omezte přístup k souboru certifikátu a získávejte jeho heslo z úložiště tajemství nebo jiného chráněného konfiguračního zdroje. Níže uvedené příklady používají proměnnou prostředí pouze proto, aby se heslo nevkládalo přímo do kódu.

## **Přidání digitálního podpisu do prezentace**

Pro podepsání reálného pracovního postupu s prezentací načtěte existující soubor PPTX, vytvořte [DigitalSignature](https://reference.aspose.com/slides/cs/java/com.aspose.slides/digitalsignature/) z PFX certifikátu a jeho hesla, přidejte podpis do kolekce prezentace a uložte do souboru PPTX.

```java
String certificatePassword = System.getenv("PFX_PASSWORD");
if (certificatePassword == null || certificatePassword.isEmpty()) {
    throw new IllegalStateException("Set the PFX_PASSWORD environment variable.");
}

Presentation presentation = new Presentation("InputPresentation.pptx");
try {
    DigitalSignature signature = new DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Uložení výsledku pod novým názvem zachová neoznačený (nepodepsaný) zdrojový soubor. Hodnota nastavená pomocí [IDigitalSignature.setComments](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) popisuje účel podpisu; nejde o bezpečnostní kontrolu.

## **Ověření digitálních podpisů**

Když načtete podepsaný soubor PPTX, zkontrolujte každou položku vrácenou metodou [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentation/#getDigitalSignatures--). Metoda [IDigitalSignature.isValid](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idigitalsignature/#isValid--) udává, zda je vložený podpis platný pro aktuální obsah prezentace.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    IDigitalSignatureCollection signatures = presentation.getDigitalSignatures();
    int signatureCount = signatures.size();

    if (signatureCount == 0) {
        System.out.println("The presentation does not contain digital signatures.");
    } else {
        boolean allSignaturesAreValid = true;
        java.text.SimpleDateFormat signTimeFormat = new java.text.SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        java.security.cert.CertificateFactory certificateFactory = java.security.cert.CertificateFactory.getInstance("X.509");

        for (IDigitalSignature signature : signatures) {
            boolean signatureIsValid = signature.isValid();
            String signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            java.util.Date signTime = signature.getSignTime();
            String formattedSignTime = signTimeFormat.format(signTime);

            byte[] certificateData = signature.getCertificate();
            java.io.ByteArrayInputStream certificateStream = new java.io.ByteArrayInputStream(certificateData);
            java.security.cert.X509Certificate certificate = (java.security.cert.X509Certificate) certificateFactory.generateCertificate(certificateStream);
            javax.security.auth.x500.X500Principal signerPrincipal = certificate.getSubjectX500Principal();
            String signerName = signerPrincipal.getName();

            System.out.println(signerName + ", " + formattedSignTime + " -- " + signatureStatus);

            allSignaturesAreValid &= signatureIsValid;
        }

        if (allSignaturesAreValid) {
            System.out.println("All embedded signatures are valid for the current presentation.");
        } else {
            System.out.println("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

Neplatný výsledek obvykle znamená, že se po podepsání změnil obsah prezentace nebo data podpisu, nebo že je soubor poškozený. Odebrání všech podpisů vytvoří nepodepsanou prezentaci, takže kontrola pouze platnosti položek není dostačující: bezpečnostně citlivý pracovní postup musí také ověřit, že je přítomen očekávaný počet podpisů a očekávané identity podepisujících.

Tento výsledek platnosti by neměl být považován za úplné rozhodnutí o důvěře v certifikát. V závislosti na vaší bezpečnostní politice může vaše aplikace také potřebovat sestavit a ověřit řetězec certifikátů X.509, zkontrolovat datum platnosti certifikátu a stav revokace, potvrdit očekávaný subjekt nebo otisk, ověřit použití klíče a vyhodnotit důvěryhodný časové razítko. Hodnota [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idigitalsignature/#getSignTime--) sama o sobě není důkaz od důvěryhodné autority časového razítka.

## **Odstranění digitálních podpisů**

Odstranění podpisů mění bezpečnostní stav prezentace. Následující příklad načte podepsaný soubor PPTX, odstraní všechny podpisy pomocí [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idigitalsignaturecollection/#clear--), a uloží nepodepsanou kopii.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pro odstranění pouze jednoho podpisu zavolejte [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) s jeho nulovým indexem. Uložte do nového souboru, pokud není přepisování původního podepsaného souboru explicitní částí vašeho pracovního postupu.

## **Úvahy o úpravách a formátech**

- Podpis neznamená, že je prezentace jen pro čtení. Uživatelé a aplikace mohou soubor nadále upravovat, ale změny podepsaného obsahu obvykle zneplatní existující podpis.
- Proveďte všechny zamýšlené úpravy před podepsáním. Pokud je nutné prezentaci změnit, uložte revidovanou verzi a podepište ji znovu.
- Uchovávejte finální výstup ve formátu PPTX. Převod podepsané prezentace do jiného formátu nepřenáší původní podpis PPTX jako platný podpis pro převedený soubor.
- Považujte soukromý klíč certifikátu za citlivý. Kdokoli, kdo získá soukromý klíč a jeho heslo, může vytvořit podpisy, které se jeví jako pocházející od držitele certifikátu.
- Uchovejte neoznačený (nepodepsaný) zdroj nebo další kontrolovanou kopii, pokud to vyžaduje vaše politika uchovávání dokumentů.

## **Často kladené otázky**

**Šifruje digitální podpis prezentaci?**

Ne. Digitální podpis poskytuje důkaz o původu a integritě, ale obsah prezentace zůstává čitelný, pokud není použita samostatná šifrování. Použijte [ochrana heslem](/java/password-protected-presentation/), když je nutné omezit přístup k obsahu.

**Je heslo PFX stejné jako heslo prezentace?**

Ne. Heslo PFX odemyká soukromý klíč uložený v balíčku certifikátu. Neurčuje, kdo může otevřít nebo upravit soubor PPTX.

**Mohu použít samopodepsaný certifikát?**

Technicky lze použít samopodepsaný certifikát, pokud obsahuje přístupný soukromý klíč. Příjemci jej však nebudou automaticky důvěřovat, pokud není tento certifikát explicitně přidán do jejich důvěryhodného prostředí. Veřejné nebo meziorganizační pracovní postupy obvykle používají certifikát vydaný důvěryhodnou CA.

**Co způsobuje, že je podpis neplatný?**

Změna podepsaného obsahu prezentace nebo dat podpisu po podepsání může podpis neplatit. Poškození souboru může také způsobit selhání ověření. Pokud jsou všechny podpisy odstraněny, prezentace je nepodepsaná, nikoli soubor obsahující neplatný podpis.

**Znamená platný podpis, že bych měl důvěřovat podepisujícímu?**

Ne, samo o sobě ne. Integrita podpisu a důvěra v podepisujícího jsou samostatná rozhodnutí. Produkční validační politika by měla také kontrolovat řetězec certifikátů, období platnosti, stav revokace, očekávanou identitu, použití klíče a případné požadavky na důvěryhodné časové razítko.

**Co se stane, když certifikát vyprší?**

Vypršení platnosti certifikátu nemění bajty prezentace, ale ovlivňuje hodnocení důvěry v certifikát. Zda podpis zůstane přijatelné, závisí na vaší politice a na tom, zda platné důvěryhodné časové razítko prokazuje, že podepsání proběhlo, když byl certifikát ještě platný. Nespoléhejte se jen na zobrazený čas podpisu jako na důvěryhodné časové razítko.

**Lze stále upravovat podepsanou prezentaci?**

Ano. Podepsání neblokuje soubor. Úprava podepsaného obsahu obvykle zneplatní existující podpis, proto nejprve dokončete prezentaci a podepište finální revizi.

**Může prezentace obsahovat více než jeden podpis?**

Ano. Přidejte každý podpis do kolekce vrácené metodou [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) před uložením. Během ověřování zkontrolujte každý podpis a potvrďte, že jsou přítomni všichni požadovaní podepisující.

**Které formáty prezentací podporují tyto operace?**

Aspose.Slides podporuje operace digitálního podpisu popsané zde pouze pro formát PPTX. Formáty PPT a OpenDocument prezentací nejsou tímto API pracovním postupem podporovány.

**Mohu odstranit podpis, aniž by to ovlivnilo snímky?**

Ano. Můžete odstranit jeden podpis nebo vyprázdnit celou kolekci a poté uložit prezentaci. Obsah snímků zůstane zachován, ale uložený soubor již neobsahuje důkaz o odstraněném podpisu.