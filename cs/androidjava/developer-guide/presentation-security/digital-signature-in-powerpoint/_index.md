---
title: Přidání digitálních podpisů do prezentací na Androidu
linktitle: Digitální podpis
type: docs
weight: 10
url: /cs/androidjava/digital-signature-in-powerpoint/
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
- Android
- Java
- Aspose.Slides
description: "Naučte se, jak podepsat existující PPTX prezentace pomocí PFX certifikátů a použít Aspose.Slides pro Android prostřednictvím Javy k ověření nebo odstranění digitálních podpisů."
---
## **Přehled**

Digitální podpis pomáhá příjemci určit, kdo prezentaci podepsal a zda se podepsaný obsah změnil. Důležité jsou zde tři související bezpečnostní koncepty:

- **Digitální certifikát** je elektronické oprávnění, které spojuje identitu s veřejným klíčem. Důvěryhodná certifikační autorita (CA) může certifikát vydat, nebo může organizace použít samopodepsaný certifikát pro interní workflow.
- **Digitální podpis** se vytváří z obsahu prezentace a soukromého klíče držitele certifikátu. Veřejný klíč certifikátu může být poté použit k ověření podpisu. Podpis poskytuje důkaz o původu a integritě; nešifruje prezentaci.
- **Ochrana heslem** určuje, zda může uživatel otevřít nebo upravit prezentaci. Je oddělena od digitálního podepisování a je popsána v [Ochrana prezentací heslem](/slides/cs/androidjava/password-protected-presentation/).

PowerPoint poskytuje příkaz **Přidat digitální podpis** pod **Soubor > Info > Zabezpečit prezentaci**.

![PowerPoint nabídka Zabezpečit prezentaci s zvýrazněnou položkou Přidat digitální podpis](add-digital-signature-in-powerpoint.png)

Po otevření podepsané prezentace může PowerPoint zobrazit oznámení o stavu podpisu.

![PowerPoint oznámení, že prezentace obsahuje platné podpisy](digital-signature-status-in-powerpoint.png)

Aspose.Slides zpřístupňuje podpisy přes [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--), který vrací [IDigitalSignatureCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idigitalsignaturecollection/) — její položky implementují [IDigitalSignature](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idigitalsignature/). Prezentace může obsahovat více podpisů.

## **Pochopení certifikátů PFX a hesel**

Soubor PFX, také známý jako soubor PKCS#12 a obvykle s příponou `.pfx` nebo `.p12`, může obsahovat certifikát X.509, jeho soukromý klíč a řetězec certifikátů. Soukromý klíč umožňuje držiteli vytvořit podpis. Certifikát bez přístupného soukromého klíče nelze použít k podepsání prezentace.

Heslo PFX chrání balíček certifikátu a soukromý klíč. Není to heslo pro otevření nebo úpravu prezentace. Neukládejte soubory PFX ani jejich hesla do systému správy zdrojového kódu. Ve výrobním prostředí omezte přístup k souboru s certifikátem a získávejte jeho heslo ze zabezpečeného úložiště nebo jiného chráněného konfiguračního zdroje. Níže uvedené příklady používají proměnnou prostředí jen proto, aby se heslo neukládalo přímo do kódu.

## **Přidání digitálního podpisu do prezentace**

Pro podepisování reálných souborů načtěte existující PPTX, vytvořte [DigitalSignature](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/digitalsignature/) z PFX certifikátu a jeho hesla, přidejte podpis do kolekce prezentace a uložte do nového PPTX souboru.

```java
import com.aspose.slides.*;

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

Uložení výsledku pod novým názvem zachová neoznačený zdrojový soubor. Hodnota nastavená pomocí [IDigitalSignature.setComments](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) popisuje účel podpisu; nejde o bezpečnostní kontrolu.

## **Ověření digitálních podpisů**

Když načtete podepsaný PPTX soubor, prozkoumejte každou položku vrácenou metodou [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--). Metoda [IDigitalSignature.isValid](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idigitalsignature/#isValid--) udává, zda je vložený podpis platný pro aktuální obsah prezentace.

```java
import com.aspose.slides.*;

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

Neplatný výsledek obvykle znamená, že se po podepsání změnil obsah prezentace nebo data podpisu, nebo že je soubor poškozen. Odstranění všech podpisů vytváří neoznačenou prezentaci, takže kontrola pouze platnosti položek nestačí: bezpečnostně citlivý workflow musí také ověřit, že je přítomen očekávaný počet podpisů a očekávané identity podepisujících.

Tento výsledek by neměl být považován za kompletní rozhodnutí o důvěře certifikátu. V závislosti na vaší bezpečnostní politice může aplikace také potřebovat vybudovat a ověřit řetězec certifikátů X.509, zkontrolovat data platnosti a stav odvolání certifikátu, potvrdit očekávaný subjekt nebo otisk, ověřit využití klíče a vyhodnotit důvěryhodné časové razítko. Hodnota vrácená metodou [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idigitalsignature/#getSignTime--) sama o sobě není důkazem od důvěryhodné autority časových razítek.

## **Odstranění digitálních podpisů**

Odstranění podpisů mění bezpečnostní stav prezentace. Následující příklad načte podepsaný PPTX soubor, odstraní všechny podpisy pomocí [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idigitalsignaturecollection/#clear--), a uloží neoznačenou kopii.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pro odstranění jen jednoho podpisu zavolejte [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) s jeho indexem (číslování od nuly). Uložte do nového souboru, pokud není přepisování původního podepsaného souboru výslovnou součástí vašeho workflow.

## **Úpravy a formátové úvahy**

- Podpis neznamená, že je prezentace jen pro čtení. Uživatelé i aplikace mohou soubor stále upravovat, ale změny podepsaného obsahu obvykle zneplatní existující podpis.
- Proveďte všechny zamýšlené úpravy před podepsáním. Pokud je nutné prezentaci změnit, uložte revidovanou verzi a podepište tuto revizi znovu.
- Uchovávejte konečný výstup ve formátu PPTX. Převod podepsané prezentace do jiného formátu nepřenáší původní PPTX podpis jako platný podpis pro převedený soubor.
- Považujte soukromý klíč certifikátu za citlivý. Kdokoli, kdo získá soukromý klíč a jeho heslo, může vytvářet podpisy, které se jeví jako pocházející od držitele certifikátu.
- Zachovejte neoznačený zdroj nebo další kontrolovanou kopii, pokud to vyžaduje vaše politika archivace dokumentů.

## **Často kladené otázky**

**Šifruje digitální podpis prezentaci?**

Ne. Digitální podpis poskytuje důkaz o původu a integritě, ale obsah prezentace zůstává čitelný, pokud není použita samostatná šifrovací ochrana. Použijte [ochranu heslem](/slides/cs/androidjava/password-protected-presentation/), pokud má být přístup k obsahu omezen.

**Je heslo PFX stejné jako heslo prezentace?**

Ne. Heslo PFX odemyká soukromý klíč uložený v balíčku certifikátu. Neovlivňuje, kdo může otevřít nebo upravit soubor PPTX.

**Mohu použít samopodepsaný certifikát?**

Technicky lze samopodepsaný certifikát použít, pokud obsahuje přístupný soukromý klíč. Příjemci jej automaticky nedůvěřují, pokud nebyl explicitně přidán do jejich důvěryhodného prostředí. Ve veřejných nebo mezi‑organizačních workflow se obvykle používá certifikát vydaný důvěryhodnou CA.

**Co způsobí, že je podpis neplatný?**

Změna obsahu podepsané prezentace nebo dat podpisu po podpisu může podpis zneplatnit. Poškození souboru také může vést k neúspěšnému ověření. Pokud jsou všechny podpisy odstraněny, prezentace je neoznačená, nikoli soubor s neplatným podpisem.

**Znamená platný podpis, že mohu důvěřovat podepisujícímu?**

Ne samostatně. Integrita podpisu a důvěra k podepisujícímu jsou oddělená rozhodnutí. Produkční politika ověřování by měla také kontrolovat řetězec certifikátů, období platnosti, stav odvolání, očekávanou identitu, využití klíče a případné požadavky na důvěryhodné časové razítko.

**Co se stane, když certifikát vyprší?**

Vypršení certifikátu nemění bajty prezentace, ale ovlivňuje hodnocení důvěry certifikátu. Zda podpis zůstane přijateľný, závisí na vaší politice a na tom, zda existuje platné důvěryhodné časové razítko prokazující, že podpis byl vytvořen během platnosti certifikátu. Nespoléhejte se jen na zobrazený čas podpisu jako na důvěryhodné časové razítko.

**Může být podepsaná prezentace stále upravována?**

Ano. Podepsání soubor neuzamkne. Úprava podepsaného obsahu obvykle zneplatní existující podpis, takže dokončete prezentaci a podepište finální revizi.

**Může prezentace obsahovat více než jeden podpis?**

Ano. Přidejte každý podpis do kolekce vrácené metodou [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) před uložením. Během ověřování prozkoumejte každý podpis a potvrďte, že jsou přítomni všichni požadovaní podepisující.

**Které formáty prezentací podporují tyto operace?**

Aspose.Slides podporuje zde popsané operace s digitálními podpisy pouze pro PPTX. Formáty PPT a OpenDocument nejsou tímto API workflow podporovány.

**Mohu odstranit podpis bez ovlivnění snímků?**

Ano. Můžete odstranit jeden podpis nebo vyprázdnit celou kolekci a pak prezentaci uložit. Obsah snímků zůstane zachován, ale uložený soubor již neobsahuje důkaz o odstraněném podpisu.