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
description: "Naučte se, jak podepsat existující PPTX prezentace pomocí PFX certifikátů a použít Aspose.Slides pro Android v Javě k ověření nebo odstranění digitálních podpisů."
---
## **Přehled**

Digitální podpis pomáhá příjemci určit, kdo prezentaci podepsal a zda se podepsaný obsah změnil. Tři související bezpečnostní koncepty jsou zde důležité:

- **digitální certifikát** je elektronické oprávnění, které spojuje identitu s veřejným klíčem. Důvěryhodná certifikační autorita (CA) může certifikát vydat, nebo organizace může použít samopodepsaný certifikát pro interní pracovní postupy.
- **digitální podpis** je vytvořen z obsahu prezentace a soukromého klíče držitele certifikátu. Veřejný klíč certifikátu lze poté použít k ověření podpisu. Podpis poskytuje důkaz o původu a integritě; nešifruje prezentaci.
- **ochrana heslem** řídí, zda může uživatel otevřít nebo upravit prezentaci. Je oddělena od digitálního podepisování a je popsána v [Prezentace chráněné heslem](/androidjava/password-protected-presentation/).

PowerPoint poskytuje příkaz **Přidat digitální podpis** pod **Soubor > Informace > Zabezpečit prezentaci**.

![Nabídka PowerPointu Zabezpečit prezentaci s vybraným Přidat digitální podpis](/add-digital-signature-in-powerpoint.png)

Po otevření podepsané prezentace může PowerPoint zobrazit oznámení o stavu podpisu.

![Upozornění PowerPointu, že prezentace obsahuje platné podpisy](/digital-signature-status-in-powerpoint.png)

Aspose.Slides zveřejňuje podpisy prostřednictvím [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--), který vrací [IDigitalSignatureCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idigitalsignaturecollection/) a jeho položky implementují [IDigitalSignature](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idigitalsignature/). Prezentace může obsahovat více podpisů.

## **Pochopit PFX certifikáty a hesla**

Soubor PFX, také známý jako soubor PKCS#12 a běžně s příponou `.pfx` nebo `.p12`, může obsahovat X.509 certifikát, jeho soukromý klíč a řetězec certifikátů. Soukromý klíč umožňuje držiteli vytvořit podpis. Certifikát bez přístupného soukromého klíče nelze použít k podepsání prezentace.

Heslo PFX chrání balík certifikátu a soukromý klíč. Není to heslo pro otevírání nebo úpravu prezentace. Neskladujte soubory PFX ani jejich hesla ve zdrojovém řízení. Ve výrobě omezte přístup k souboru certifikátu a získejte jeho heslo z úložiště tajemství nebo jiného chráněného konfiguračního zdroje. Níže uvedené příklady používají proměnnou prostředí pouze kvůli tomu, aby se heslo neembedovalo přímo v kódu.

## **Přidat digitální podpis do prezentace**

Pro podepsání reálného pracovního postupu načtěte existující soubor PPTX, vytvořte [DigitalSignature](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/digitalsignature/) z PFX certifikátu a jeho hesla, přidejte podpis do kolekce prezentace a uložte do souboru PPTX.

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

Uložení výsledku pod novým názvem zachová nepodepsaný zdrojový soubor. Hodnota nastavená metodou [IDigitalSignature.setComments](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) popisuje účel podpisu; není to bezpečnostní kontrola.

## **Ověřit digitální podpisy**

Když načtete podepsaný soubor PPTX, prozkoumejte každou položku vrácenou metodou [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--). Metoda [IDigitalSignature.isValid](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idigitalsignature/#isValid--) udává, zda je vložený podpis platný pro aktuální obsah prezentace.

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

Neplatný výsledek obvykle znamená, že po podepsání došlo ke změně obsahu prezentace nebo dat podpisu, nebo že soubor je poškozen. Odstranění všech podpisů vytvoří nepodepsanou prezentaci, takže kontrola pouze platnosti položek není dostatečná: bezpečnostně citlivý pracovní postup musí také ověřit, že je přítomen očekávaný počet podpisů a očekávané identity podepisujících.

Tento výsledek platnosti by neměl být považován za úplné rozhodnutí o důvěře certifikátu. V závislosti na vaší bezpečnostní politice může vaše aplikace také potřebovat sestavit a ověřit řetězec certifikátů X.509, zkontrolovat datum platnosti certifikátu a stav odvolání, potvrdit očekávaný subjekt nebo otisk, ověřit použití klíče a vyhodnotit důvěryhodný časový razítko. Hodnota vrácená metodou [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idigitalsignature/#getSignTime--) sama o sobě není důkazem od důvěryhodné autority časových razítek.

## **Odstranit digitální podpisy**

Odstranění podpisů mění bezpečnostní stav prezentace. Následující příklad načte podepsaný soubor PPTX, odstraní všechny podpisy pomocí [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idigitalsignaturecollection/#clear--), a uloží nepodepsanou kopii.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Chcete-li odstranit pouze jeden podpis, zavolejte [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) s jeho nulovým indexem. Uložte do nového souboru, pokud není přepisování podepsaného originálu explicitní součástí vašeho pracovního postupu.

## **Úpravy a úvahy o formátu**

- Podpis nečiní prezentaci jen pro čtení. Uživatelé a aplikace mohou soubor i nadále upravovat, ale změny podepsaného obsahu obvykle neplatný existující podpis.
- Proveďte všechny zamýšlené úpravy před podepsáním. Pokud musí být prezentace změněna, uložte upravenou verzi a podepište ji znovu.
- Uchovávejte finální výstup ve formátu PPTX. Převod podepsané prezentace do jiného formátu nepřenáší původní podpis PPTX jako platný podpis pro převedený soubor.
- Zacházejte se soukromým klíčem certifikátu jako s citlivou informací. Kdokoli, kdo získá soukromý klíč a jeho heslo, může vytvářet podpisy, které se jeví jako pocházející od držitele certifikátu.
- Uchovejte nepodepsaný zdroj nebo jinou kontrolovanou kopii, pokud to vyžaduje politika archivace dokumentů.

## **Často kladené otázky**

**Zda digitální podpis šifruje prezentaci?**

Ne. Digitální podpis poskytuje důkaz o původu a integritě, ale obsah prezentace zůstává čitelný, pokud není aplikováno samostatné šifrování. Použijte [ochranu heslem](/androidjava/password-protected-presentation/), když je nutné omezit přístup k obsahu.

**Je heslo PFX stejné jako heslo prezentace?**

Ne. Heslo PFX odemyká soukromý klíč uložený v balíku certifikátu. Neřídí, kdo může otevřít nebo upravit soubor PPTX.

**Mohu použít samopodepsaný certifikát?**

Technicky lze použít samopodepsaný certifikát, pokud obsahuje přístupný soukromý klíč. Příjemci jej nebudou automaticky důvěřovat, pokud není výslovně přidán do jejich důvěryhodného prostředí. Ve veřejných nebo meziosobních pracovních postupech se obvykle používá certifikát vydaný důvěryhodnou CA.

**Co činí podpis neplatným?**

Změna podepsaného obsahu prezentace nebo dat podpisu po podepsání může podpis neplatit. Poškození souboru může také způsobit selhání validace. Pokud jsou všechny podpisy odstraněny, prezentace je nepodepsaná místo souboru s neplatným podpisem.

**Znamená platný podpis, že mohu důvěřovat podepisujícímu?**

Ne samotný. Integrita podpisu a důvěra k podepisujícímu jsou samostatná rozhodnutí. Produkční validační politika by také měla kontrolovat řetězec certifikátů, dobu platnosti, stav odvolání, očekávanou identitu, použití klíče a případné požadavky na důvěryhodné časové razítko.

**Co se stane, když certifikát vyprší?**

Vypršení certifikátu nemění bajty prezentace, ale ovlivňuje hodnocení důvěry certifikátu. Zda podpis zůstane přijatelný, závisí na vaší politice a na tom, zda platné důvěryhodné časové razítko prokáže, že podepsání proběhlo během platnosti certifikátu. Nespoléhejte se pouze na zobrazený čas podpisu jako na důvěryhodné časové razítko.

**Může být podepsaná prezentace stále upravována?**

Ano. Podepisování neblokuje soubor. Úprava podepsaného obsahu obvykle způsobí neplatnost existujícího podpisu, proto dokončete prezentaci a podepište finální revizi.

**Může prezentace obsahovat více než jeden podpis?**

Ano. Přidejte každý podpis do kolekce vrácené metodou [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) před uložením. Během validace prověřte každý podpis a potvrďte, že jsou přítomni všichni požadovaní podepisující.

**Které formáty prezentací podporují tyto operace?**

Aspose.Slides podporuje operace s digitálními podpisy popsané zde pouze pro PPTX. Formáty PPT a OpenDocument nejsou touto API podporovány.

**Mohu odstranit podpis bez ovlivnění snímků?**

Ano. Můžete odstranit jeden podpis nebo vyprázdnit celou kolekci a poté uložit prezentaci. Obsah snímků zůstane zachován, ale uložený soubor již neobsahuje důkazy o odstraněném podpisu.