---
title: Přidání digitálních podpisů do prezentací v jazyce Java
linktitle: Digitální podpis
type: docs
weight: 10
url: /cs/java/digital-signature-in-powerpoint/
keywords:
- digitální podpis
- digitální certifikát
- certifikační autorita
- PFX certifikát
- PKCS#12
- ověřit podpis
- PowerPoint
- PPTX
- bezpečnost prezentace
- Java
- Aspose.Slides
description: "Zjistěte, jak podepsat existující PPTX prezentace pomocí PFX certifikátů a použít Aspose.Slides pro Java k ověření nebo odebrání digitálních podpisů."
---
## **Přehled**

Digitální podpis pomáhá příjemci určit, kdo prezentaci podepsal a zda se podepsaný obsah změnil. Důležité jsou zde tři související bezpečnostní pojmy:

- **digitální certifikát** je elektronické osvědčení, které spojuje identitu s veřejným klíčem. Důvěryhodná certifikační autorita (CA) může vydat certifikát, nebo organizace může použít samopodepsaný certifikát pro interní pracovní postupy.
- **digitální podpis** se vytváří z obsahu prezentace a soukromého klíče vlastníka certifikátu. Veřejný klíč certifikátu se pak použije k ověření podpisu. Podpis poskytuje důkaz o původu a integritě; nešifruje prezentaci.
- **Ochrana heslem** řídí, zda uživatel může otevřít nebo upravit prezentaci. Je oddělena od digitálního podepisování a je popsána v [Prezentace chráněné heslem](/slides/cs/java/password-protected-presentation/).

PowerPoint poskytuje příkaz **Add a Digital Signature** pod **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

Po otevření podepsané prezentace může PowerPoint zobrazit oznámení o stavu podpisu.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides zpřístupňuje podpisy přes [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/cs/java/com.aspose.slides.ipresentation/#getDigitalSignatures--), který vrací [IDigitalSignatureCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides.idigitalsignaturecollection/) jejíž položky implementují [IDigitalSignature](https://reference.aspose.com/slides/cs/java/com.aspose.slides.idigitalsignature/). Prezentace může obsahovat více podpisů.

## **Pochopení certifikátů PFX a hesel**

Soubor PFX, také známý jako soubor PKCS#12 a běžně s příponou `.pfx` nebo `.p12`, může obsahovat certifikát X.509, jeho soukromý klíč a řetězec certifikátů. Soukromý klíč umožňuje vlastníku vytvořit podpis. Certifikát bez přístupného soukromého klíče nelze použít k podepsání prezentace.

Heslo PFX chrání balíček certifikátu a soukromý klíč. Není to heslo pro otevření nebo úpravu prezentace. Neskladujte soubory PFX ani jejich hesla do systémů pro správu verzí. Ve výrobě omezte přístup k souboru certifikátu a získávejte heslo z úložiště tajemství nebo jiného chráněného zdroje konfigurace. Níže uvedené příklady používají proměnnou prostředí pouze kvůli vyhnutí se zakódování hesla v kódu.

## **Přidání digitálního podpisu do prezentace**

Pro podepsání reálného pracovního postupu načtěte existující soubor PPTX, vytvořte [DigitalSignature](https://reference.aspose.com/slides/cs/java/com.aspose.slides.digitalsignature/) z PFX certifikátu a jeho hesla, přidejte podpis do kolekce prezentace a uložte do souboru PPTX.

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

Uložení výsledku pod novým názvem zachovává ne-podepsaný zdrojový soubor. Hodnota nastavená pomocí [IDigitalSignature.setComments](https://reference.aspose.com/slides/cs/java/com.aspose.slides.idigitalsignature/#setComments-java.lang.String-) popisuje účel podpisu; není to bezpečnostní kontrola.

## **Ověření digitálních podpisů**

Když načtete podepsaný soubor PPTX, prozkoumejte každou položku vrácenou metodou [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/cs/java/com.aspose.slides.ipresentation/#getDigitalSignatures--). Metoda [IDigitalSignature.isValid](https://reference.aspose.com/slides/cs/java/com.aspose.slides.idigitalsignature/#isValid--) udává, zda je vložený podpis platný pro aktuální obsah prezentace.

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

Neplatný výsledek obvykle znamená, že se po podepsání změnil obsah prezentace nebo data podpisu, nebo že je soubor poškozen. Odebráním všech podpisů vznikne nepodepsaná prezentace, takže kontrola pouze platnosti položek nestačí: workflow citlivý na zabezpečení musí také ověřit, že je přítomen očekávaný počet podpisů a očekávané identity podepisujících.

Tento výsledek by neměl být považován za kompletní rozhodnutí o důvěře v certifikát. Podle vaší bezpečnostní politiky může vaše aplikace také potřebovat sestavit a ověřit řetězec certifikátů X.509, zkontrolovat platnost certifikátu a stav revokace, potvrdit očekávaný subjekt nebo otisk, ověřit použití klíče a vyhodnotit důvěryhodný časový razítko. Hodnota z [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/cs/java/com.aspose.slides.idigitalsignature/#getSignTime--) sama o sobě není důkaz od důvěryhodné autority časových razítek.

## **Odebrání digitálních podpisů**

Odebrání podpisů mění bezpečnostní stav prezentace. Následující příklad načte podepsaný soubor PPTX, odebere všechny podpisy pomocí [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/cs/java/com.aspose.slides.idigitalsignaturecollection/#clear--), a uloží nepodepsanou kopii.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pro odebrání jen jednoho podpisu zavolejte [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/cs/java/com.aspose.slides.idigitalsignaturecollection/#removeAt-int-) s jeho nulovým indexem. Uložte do nového souboru, pokud nepřepisování podepsaného originálu není explicitní součástí vašeho workflow.

## **Úvahy o úpravách a formátech**

- Podpis neznemožňuje úpravu prezentace. Uživatelé a aplikace mohou soubor stále editovat, ale změny podepsaného obsahu obvykle neplatný existující podpis.
- Proveďte všechny zamýšlené úpravy před podepsáním. Pokud je třeba prezentaci změnit, uložte revidovanou verzi a podepište ji znovu.
- Zachovejte finální výstup ve formátu PPTX. Převod podepsané prezentace do jiného formátu nepřenáší původní PPTX podpis jako platný podpis pro převedený soubor.
- Zacházejte se soukromým klíčem certifikátu jako s citlivým údajem. Kdokoli, kdo získá soukromý klíč a jeho heslo, může vytvářet podpisy, které se tváří jako pocházející od držitele certifikátu.
- Uchovávejte ne-podepsaný zdroj nebo jinou kontrolovanou kopii, pokud to vyžaduje vaše politika archivace dokumentů.

## **Často kladené otázky**

**Šifruje digitální podpis prezentaci?**

Ne. Digitální podpis poskytuje důkaz o původu a integritě, ale obsah prezentace zůstává čitelný, pokud není aplikováno samostatné šifrování. Použijte [ochranu heslem](/slides/cs/java/password-protected-presentation/), když je potřeba omezit přístup k obsahu.

**Je heslo PFX stejné jako heslo prezentace?**

Ne. Heslo PFX odemyká soukromý klíč uložený v balíčku certifikátu. Nereguluje, kdo může otevřít nebo editovat soubor PPTX.

**Mohu použít samopodepsaný certifikát?**

Technicky lze použít samopodepsaný certifikát, pokud obsahuje přístupný soukromý klíč. Příjemci jej nebudou automaticky důvěřovat, pokud není výslovně přidán do jejich důvěryhodného prostředí. Ve veřejných nebo meziorganizačních pracovních postupech se obvykle používá certifikát vydaný důvěryhodnou CA.

**Co způsobí, že je podpis neplatný?**

Změna podepsaného obsahu prezentace nebo dat podpisu po podepsání může podpis neplatit. Poškození souboru může také vést k selhání ověření. Pokud jsou odebrány všechny podpisy, prezentace je nepodepsaná, nikoli soubor s neplatným podpisem.

**Znamená platný podpis, že mohu důvěřovat podepisujícímu?**

Ne samostatně. Integrita podpisu a důvěra v podepisujícího jsou samostatná rozhodnutí. Politika ověřování ve výrobě by měla také kontrolovat řetězec certifikátů, období platnosti, stav revokace, očekávanou identitu, použití klíče a případné požadavky na důvěryhodné časové razítko.

**Co se stane, když certifikát vyprší?**

Vypršení certifikátu nemění bajty prezentace, ale ovlivňuje hodnocení důvěry v certifikát. Zda podpis zůstane přijatelný, závisí na vaší politice a na tom, zda důvěryhodné časové razítko prokáže, že podpis byl vytvořen, když byl certifikát stále platný. Nespoléhejte se pouze na zobrazený čas podpisu jako na důvěryhodné časové razítko.

**Může být podepsaná prezentace stále upravována?**

Ano. Podepsání neuzamyká soubor. Úprava podepsaného obsahu obvykle způsobí neplatnost existujícího podpisu, proto dokončete prezentaci před jejím podpisem.

**Může prezentace obsahovat více než jeden podpis?**

Ano. Přidejte každý podpis do kolekce vrácené metodou [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/cs/java/com.aspose.slides.ipresentation/#getDigitalSignatures--) před uložením. Během ověřování prozkoumejte každý podpis a potvrďte, že jsou přítomni všichni požadovaní podepisující.

**Které formáty prezentací podporují tyto operace?**

Aspose.Slides podporuje operace s digitálními podpisy popsané zde pouze pro PPTX. Formáty PPT a OpenDocument nejsou tímto API pracovním postupem podporovány.

**Mohu odebrat podpis bez ovlivnění snímků?**

Ano. Můžete odebrat jeden podpis nebo vyprázdnit celou kolekci a pak uložit prezentaci. Obsah snímků zůstane zachován, ale uložený soubor již neobsahuje důkaz o odebraném podpisu.