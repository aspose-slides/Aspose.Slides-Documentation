---
title: Přidání digitálních podpisů do prezentací v Pythonu
linktitle: Digitální podpis
type: docs
weight: 10
url: /cs/python-java/digital-signature-in-powerpoint/
keywords:
- digitální podpis
- digitální certifikát
- certifikační autorita
- PFX certifikát
- PKCS#12
- ověření podpisu
- PowerPoint
- PPTX
- bezpečnost prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak podepsat existující PPTX prezentace pomocí PFX certifikátů a použít Aspose.Slides pro Python přes Java k ověření nebo odebrání digitálních podpisů."
---
## **Přehled**

Digitální podpis pomáhá příjemci určit, kdo podepsal prezentaci a zda se podepsaný obsah změnil. Jsou zde důležité tři související bezpečnostní pojmy:

- **digitální certifikát** je elektronické oprávnění, které spojuje identitu s veřejným klíčem. Důvěryhodná certifikační autorita (CA) může certifikát vydat, nebo organizace může použít samopodepsaný certifikát pro interní workflow.
- **digitální podpis** je vytvořen z obsahu prezentace a privátního klíče držitele certifikátu. Veřejný klíč certifikátu může být poté použit k ověření podpisu. Podpis poskytuje důkaz o původu a integritě; nešifruje prezentaci.
- **ochrana heslem** řídí, zda uživatel může otevřít nebo upravit prezentaci. Je oddělená od digitálního podepisování a je popsána v [Password-Protected Presentations](/slides/cs/python-java/password-protected-presentation/).

PowerPoint poskytuje příkaz **Add a Digital Signature** v nabídce **File > Info > Protect Presentation**.

![Nabídka Ochrana prezentace v PowerPointu s vyznačeným Přidat digitální podpis](add-digital-signature-in-powerpoint.png)

Po otevření podepsané prezentace může PowerPoint zobrazit oznámení o stavu podpisu.

![Oznámení PowerPointu, že prezentace obsahuje platné podpisy](digital-signature-status-in-powerpoint.png)

Aspose.Slides zpřístupňuje podpisy přes [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getDigitalSignatures), který vrací [DigitalSignatureCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/digitalsignaturecollection/) s položkami typu [DigitalSignature](https://reference.aspose.com/slides/cs/python-java/aspose.slides/digitalsignature/). Prezentace může obsahovat více podpisů.

## **Porozumění PFX certifikátům a heslům**

Soubor PFX, také známý jako PKCS#12 a běžně s příponou `.pfx` nebo `.p12`, může obsahovat X.509 certifikát, jeho privátní klíč a řetězec certifikátů. Privátní klíč umožňuje držiteli vytvořit podpis. Certifikát bez přístupného privátního klíče nelze použít k podepsání prezentace.

Heslo PFX chrání balíček certifikátu a privátní klíč. Není to heslo pro otevření nebo úpravu prezentace. Nepřidávejte soubory PFX ani jejich hesla do zdrojového kódu. Ve výrobním prostředí omezte přístup k souboru certifikátu a získávejte jeho heslo z úložiště tajemství nebo jiného zabezpečeného zdroje konfigurace. V níže uvedených příkladech se používá proměnná prostředí jen kvůli vyhnutí se vložení hesla do kódu.

## **Přidání digitálního podpisu do prezentace**

Pro workflow podepisování reálné prezentace načtěte existující soubor PPTX, vytvořte [DigitalSignature](https://reference.aspose.com/slides/cs/python-java/aspose.slides/digitalsignature/) z PFX certifikátu a jeho hesla, přidejte podpis do kolekce prezentace a uložte do souboru PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

import os
from asposeslides.api import Presentation, DigitalSignature, SaveFormat

certificate_password = os.environ.get("PFX_PASSWORD")
if not certificate_password:
    print("Set the PFX_PASSWORD environment variable.")
else:
    presentation = Presentation("InputPresentation.pptx")
    try:
        signature = DigitalSignature("signing-certificate.pfx", certificate_password)
        signature.setComments("Approved for release.")

        presentation.getDigitalSignatures().add(signature)
        presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

Uložení výsledku pod novým názvem zachová neoznačený zdrojový soubor. Hodnota nastavená metodou [DigitalSignature.setComments](https://reference.aspose.com/slides/cs/python-java/aspose.slides/digitalsignature/#setComments) popisuje účel podpisu; nejde o bezpečnostní kontrolu.

## **Ověření digitálních podpisů**

Když načtete podepsaný soubor PPTX, prozkoumejte každou položku vrácenou metodou [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getDigitalSignatures). Metoda [DigitalSignature.isValid](https://reference.aspose.com/slides/cs/python-java/aspose.slides/digitalsignature/#isValid) udává, zda je vložený podpis platný pro aktuální obsah prezentace.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
CertificateFactory = jpype.JClass("java.security.cert.CertificateFactory")
SimpleDateFormat = jpype.JClass("java.text.SimpleDateFormat")

presentation = Presentation("InputPresentation-signed.pptx")
try:
    signatures = presentation.getDigitalSignatures()
    signature_count = signatures.size()

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True
        sign_time_format = SimpleDateFormat("yyyy-MM-dd HH:mm:ss")
        certificate_factory = CertificateFactory.getInstance("X.509")

        for signature in signatures:
            signature_is_valid = signature.isValid()
            signature_status = "VALID" if signature_is_valid else "INVALID"
            sign_time = signature.getSignTime()
            formatted_sign_time = sign_time_format.format(sign_time)

            certificate_data = signature.getCertificate()
            certificate_stream = ByteArrayInputStream(certificate_data)
            certificate = certificate_factory.generateCertificate(certificate_stream)
            signer_principal = certificate.getSubjectX500Principal()
            signer_name = signer_principal.getName()

            print(f"{signer_name}, {formatted_sign_time} -- {signature_status}")

            all_signatures_are_valid = all_signatures_are_valid and signature_is_valid

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
finally:
    presentation.dispose()
```

Neplatný výsledek obvykle znamená, že se po podepsání změnil obsah prezentace nebo data podpisu, nebo že soubor je poškozen. Odebrání všech podpisů vytvoří neoznačenou prezentaci, takže kontrola jen platnosti položek nestačí: bezpečnostně citlivé workflow musí také ověřit, že je přítomen očekávaný počet podpisů a očekávané identity podepisujících.

Tento výsledek by neměl být považován za kompletní rozhodnutí o důvěře v certifikát. V závislosti na vaší bezpečnostní politice může vaše aplikace také potřebovat sestavit a ověřit řetězec X.509 certifikátů, zkontrolovat datum platnosti a stav odvolání certifikátu, potvrdit očekávaný subjekt nebo otisk, ověřit použití klíče a vyhodnotit důvěryhodný časový razítko. Hodnota z [DigitalSignature.getSignTime](https://reference.aspose.com/slides/cs/python-java/aspose.slides/digitalsignature/#getSignTime) sama o sobě není důkazem od důvěryhodné autority časových razítek.

## **Odebrání digitálních podpisů**

Odebrání podpisů mění bezpečnostní stav prezentace. Následující příklad načte podepsaný soubor PPTX, odstraní všechny podpisy pomocí [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/cs/python-java/aspose.slides/digitalsignaturecollection/#clear) a uloží neoznačenou kopii.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("InputPresentation-signed.pptx")
try:
    presentation.getDigitalSignatures().clear()
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pro odebrání jen jednoho podpisu zavolejte [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/digitalsignaturecollection/#removeAt) s jeho nulovým indexem. Uložte do nového souboru, pokud není přepisování podepsaného originálu explicitní součástí vašeho workflow.

## **Úvahy o úpravách a formátech**

- Podpis neznamená, že je prezentace jen pro čtení. Uživatelé a aplikace mohou soubor stále upravovat, ale změny podepsaného obsahu obvykle neplatí existující podpis.
- Proveďte všechny zamýšlené úpravy před podepsáním. Pokud je nutné prezentaci změnit, uložte revidovanou verzi a podepište ji znovu.
- Uchovávejte konečný výstup ve formátu PPTX. Převod podepsané prezentace do jiného formátu nepřenáší původní PPTX podpis jako platný podpis pro konvertovaný soubor.
- Zacházejte s privátním klíčem certifikátu jako s citlivou informací. Kdokoli, kdo získá privátní klíč a jeho heslo, může vytvářet podpisy, které se jeví jako pocházející od držitele certifikátu.
- Uchovejte neoznačený zdroj nebo další kontrolovanou kopii, pokud to vyžaduje vaše politika archivace dokumentů.

## **Často kladené otázky**

**Šifruje digitální podpis prezentaci?**

Ne. Digitální podpis poskytuje důkaz o původu a integritě, ale obsah prezentace zůstává čitelný, pokud není použita samostatná šifrovací vrstva. Použijte [password protection](/slides/cs/python-java/password-protected-presentation/), když je nutné omezit přístup k obsahu.

**Je heslo PFX stejné jako heslo prezentace?**

Ne. Heslo PFX odemyká privátní klíč uložený v balíčku certifikátu. Neřídí, kdo může otevřít nebo upravit soubor PPTX.

**Mohu použít samopodepsaný certifikát?**

Technicky lze samopodepsaný certifikát použít, pokud obsahuje přístupný privátní klíč. Příjemci jej automaticky nebudou důvěřovat, pokud nebyl explicitně přidán do jejich důvěryhodného prostředí. Ve veřejných nebo napříč organizacemi běžících workflow se obvykle používá certifikát vydaný důvěryhodnou CA.

**Co způsobí, že je podpis neplatný?**

Změna podepsaného obsahu prezentace nebo dat podpisu po podepsání může podpis neplatnit. Poškození souboru může také způsobit neúspěšné ověření. Pokud jsou všechny podpisy odstraněny, prezentace je neoznačená, nikoli soubor s neplatným podpisem.

**Znamená platný podpis, že bych měl důvěřovat podepisujícímu?**

Ne samostatně. Integrita podpisu a důvěra k podepisujícímu jsou oddělená rozhodnutí. Politika ověřování v produkci by měla také kontrolovat řetězec certifikátů, dobu platnosti, stav odvolání, očekávanou identitu, použití klíče a případné požadavky na důvěryhodné časové razítko.

**Co se stane, když certifikát expiruje?**

Expirace certifikátu nemění bajty prezentace, ale ovlivňuje hodnocení důvěry v certifikát. Zda podpis zůstane přijatelný, závisí na vaší politice a na tom, zda platné důvěryhodné časové razítko prokazuje, že podepsání proběhlo během platnosti certifikátu. Nespoléhejte se pouze na zobrazený čas podpisu jako na důvěryhodné časové razítko.

**Může být podepsaná prezentace stále upravována?**

Ano. Podepsání soubor neuzamkne. Úprava podepsaného obsahu obvykle způsobí, že existující podpis přestane být platný, proto dokončete prezentaci před jejím podpisem.

**Může prezentace obsahovat více než jeden podpis?**

Ano. Přidejte každý podpis do kolekce vrácené metodou [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getDigitalSignatures) před uložením. Během ověřování prozkoumejte každý podpis a potvrďte, že jsou přítomni všichni požadovaní podepisující.

**Které formáty prezentací podporují tyto operace?**

Aspose.Slides podporuje operace s digitálními podpisy popsané zde pouze pro PPTX. Formáty PPT a OpenDocument nejsou tímto API workflow podporovány.

**Mohu odebrat podpis bez ovlivnění snímků?**

Ano. Můžete odebrat jeden podpis nebo vyprázdnit celou kolekci a poté prezentaci uložit. Obsah snímků zůstane zachován, ale uložený soubor již neobsahuje důkaz o odebraném podpisu.