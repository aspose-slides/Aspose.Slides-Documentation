---
title: Přidání digitálních podpisů do prezentací v Pythonu
linktitle: Digitální podpis
type: docs
weight: 10
url: /cs/python-net/digital-signature-in-powerpoint/
keywords:
- digitální podpis
- digitální certifikát
- certifikační autorita
- PFX certifikát
- PKCS#12
- ověřit podpis
- PowerPoint
- PPTX
- zabezpečení prezentací
- Python
- Aspose.Slides
description: "Naučte se, jak podepsat existující PPTX prezentace pomocí PFX certifikátů a využít Aspose.Slides pro Python prostřednictvím .NET k ověření nebo odstranění digitálních podpisů."
---
## **Přehled**

Digitální podpis pomáhá příjemci zjistit, kdo prezentaci podepsal a zda se podepsaný obsah změnil. Tři související bezpečnostní koncepty jsou zde důležité:

- **Digitální certifikát** je elektronické oprávnění, které spojuje identitu s veřejným klíčem. Důvěryhodná certifikační autorita (CA) může certifikát vydat, nebo organizace může pro interní pracovní postupy použít samopodepsaný certifikát.
- **Digitální podpis** je vytvořen z obsahu prezentace a soukromého klíče držitele certifikátu. Veřejný klíč certifikátu může být následně použit k ověření podpisu. Podpis poskytuje důkaz o původu a integritě; nešifruje prezentaci.
- **Ochrana heslem** řídí, zda může uživatel otevřít nebo upravit prezentaci. Je oddělená od digitálního podepisování a je popsána v [Prezentace chráněné heslem](/python-net/password-protected-presentation/).

PowerPoint nabízí příkaz **Add a Digital Signature** v nabídce **File > Info > Protect Presentation**.

![Menu PowerPoint Protect Presentation s vyznačenou možností Add a Digital Signature](add-digital-signature-in-powerpoint.png)

Po otevření podepsané prezentace může PowerPoint zobrazit oznámení o stavu podpisu.

![Upozornění PowerPoint, že prezentace obsahuje platné podpisy](digital-signature-status-in-powerpoint.png)

Aspose.Slides vystavuje podpisy prostřednictvím [Presentation.digital_signatures](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/digital_signatures/), [DigitalSignatureCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/digitalsignaturecollection/) jejíž položky jsou objekty [DigitalSignature](https://reference.aspose.com/slides/cs/python-net/aspose.slides/digitalsignature/). Prezentace může obsahovat více podpisů.

## **Pochopení certifikátů PFX a hesel**

Soubor PFX, také známý jako soubor PKCS#12 a běžně s příponou `.pfx` nebo `.p12`, může obsahovat certifikát X.509, jeho soukromý klíč a řetězec certifikátů. Soukromý klíč umožňuje držiteli vytvořit podpis. Certifikát bez přístupného soukromého klíče nelze použít k podepsání prezentace.

Heslo PFX chrání balíček certifikátu a soukromý klíč. Není to heslo pro otevření nebo úpravu prezentace. Nepřidávejte soubory PFX ani jejich hesla do zdrojového řízení. Ve výrobě omezte přístup k souboru certifikátu a získávejte jeho heslo z tajného úložiště nebo jiného chráněného konfiguračního zdroje. Příklady níže používají proměnnou prostředí pouze pro vyhnutí se vložení hesla do kódu.

## **Přidání digitálního podpisu do prezentace**

Pro podepsání reálného pracovního postupu načtěte existující soubor PPTX, vytvořte [DigitalSignature](https://reference.aspose.com/slides/cs/python-net/aspose.slides/digitalsignature/) z PFX certifikátu a jeho hesla, přidejte podpis do kolekce prezentace a uložte do souboru PPTX.

```python
import os
import aspose.slides as slides

certificate_password = os.environ.get("PFX_PASSWORD")
if certificate_password is None:
    raise RuntimeError("Set the PFX_PASSWORD environment variable.")

with slides.Presentation("InputPresentation.pptx") as presentation:
    signature = slides.DigitalSignature("signing-certificate.pfx", certificate_password)
    signature.comments = "Approved for release."

    presentation.digital_signatures.add(signature)
    presentation.save("InputPresentation-signed.pptx", slides.export.SaveFormat.PPTX)
```

Uložení výsledku pod novým názvem zachová neoznačený zdrojový soubor. Hodnota [DigitalSignature.comments](https://reference.aspose.com/slides/cs/python-net/aspose.slides/digitalsignature/comments/) popisuje účel podpisu; nejde o bezpečnostní kontrolu.

## **Ověření digitálních podpisů**

Když načtete podepsaný soubor PPTX, prohlédněte každou položku v [Presentation.digital_signatures](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/digital_signatures/). Vlastnost [DigitalSignature.is_valid](https://reference.aspose.com/slides/cs/python-net/aspose.slides/digitalsignature/is_valid/) udává, zda je vložený podpis platný pro aktuální obsah prezentace.

```python
import hashlib
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    signature_count = len(presentation.digital_signatures)

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True

        for signature in presentation.digital_signatures:
            signature_status = "VALID" if signature.is_valid else "INVALID"
            certificate_fingerprint = hashlib.sha256(signature.certificate).hexdigest().upper()
            signing_time = signature.sign_time.strftime("%Y-%m-%d %H:%M:%S")

            print(
                f"Certificate SHA-256: {certificate_fingerprint}, "
                f"{signing_time} -- {signature_status}"
            )

            all_signatures_are_valid = (all_signatures_are_valid and signature.is_valid)

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
```

Neplatný výsledek obvykle znamená, že se po podepsání změnil obsah prezentace nebo data podpisu, nebo že je soubor poškozený. Odebrání všech podpisů vytvoří neoznačenou prezentaci, takže kontrola pouze platnosti položek nestačí: workflow citlivé na zabezpečení musí také ověřit, že je přítomen očekávaný počet podpisů a očekávané identity podepisujících.

Vlastnost [DigitalSignature.certificate](https://reference.aspose.com/slides/cs/python-net/aspose.slides/digitalsignature/certificate/) poskytuje data certifikátu jako pole bajtů. Příklad vypočítá jeho otisk SHA-256, aby aplikace mohla porovnat s otiskem očekávaného certifikátu podepisujícího.

Tento výsledek platnosti by neměl být považován za úplné rozhodnutí o důvěře v certifikát. V závislosti na vaší bezpečnostní politice může vaše aplikace také potřebovat vytvořit a ověřit řetězec certifikátů X.509, zkontrolovat data platnosti certifikátu a stav revokace, potvrdit očekávaný subjekt nebo otisk, ověřit použití klíče a posoudit důvěryhodnou časovou značku. Hodnota [DigitalSignature.sign_time](https://reference.aspose.com/slides/cs/python-net/aspose.slides/digitalsignature/sign_time/) sama o sobě není důkazem od důvěryhodné autority časových značek.

## **Odstranění digitálních podpisů**

Odstranění podpisů mění bezpečnostní stav prezentace. Následující příklad načte podepsaný soubor PPTX, odebere všechny podpisy pomocí [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/cs/python-net/aspose.slides/digitalsignaturecollection/clear/), a uloží neoznačenou kopii.

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

Pro odebrání pouze jednoho podpisu zavolejte [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/cs/python-net/aspose.slides/digitalsignaturecollection/remove_at/) s jeho nulovým indexem. Uložte do nového souboru, pokud není přepsání podepsaného originálu explicitní součástí vašeho workflow.

## **Úpravy a úvahy o formátu**

- Podpis neznamená, že je prezentace jen pro čtení. Uživatelé a aplikace mohou soubor stále upravovat, ale změny podepsaného obsahu obvykle zneplatní existující podpis.
- Proveďte všechny zamýšlené úpravy před podepsáním. Pokud je nutné prezentaci změnit, uložte revidovanou verzi a podepište ji znovu.
- Uchovávejte finální výstup ve formátu PPTX. Převod podepsané prezentace do jiného formátu nepřenáší původní PPTX podpis jako platný podpis pro konvertovaný soubor.
- Zacházejte se soukromým klíčem certifikátu jako s citlivým údajem. Kdokoli, kdo získá soukromý klíč a jeho heslo, může vytvářet podpisy, které se jeví jako pocházející od držitele certifikátu.
- Uchovávejte neoznačený zdroj nebo jinou kontrolovanou kopii, pokud to vyžaduje vaše politika uchovávání dokumentů.

## **Často kladené otázky**

**Šifruje digitální podpis prezentaci?**

Ne. Digitální podpis poskytuje důkaz o původu a integritě, ale obsah prezentace zůstává čitelný, pokud není použito samostatné šifrování. Použijte [prezentace chráněné heslem](/python-net/password-protected-presentation/), když je nutné omezit přístup k obsahu.

**Je heslo PFX stejné jako heslo prezentace?**

Ne. Heslo PFX odemkne soukromý klíč uložený v balíčku certifikátu. Nereguluje, kdo může otevřít nebo upravit soubor PPTX.

**Mohu použít samopodepsaný certifikát?**

Technicky lze použít samopodepsaný certifikát, pokud obsahuje přístupný soukromý klíč. Příjemci jej nebudou automaticky důvěřovat, pokud není tento certifikát explicitně přidán do jejich důvěryhodného prostředí. Ve veřejných nebo meziorganizačních pracovních postupech se běžně používá certifikát vydaný důvěryhodnou CA.

**Co způsobí, že je podpis neplatný?**

Změna podepsaného obsahu prezentace nebo dat podpisu po podepsání může podpis neplatnit. Poškození souboru může také způsobit selhání ověření. Pokud jsou odebrány všechny podpisy, prezentace je neoznačená, nikoli soubor s neplatným podpisem.

**Znamená platný podpis, že mohu důvěřovat podepisujícímu?**

Ne samostatně. Integrita podpisu a důvěra v podepisujícího jsou oddělená rozhodnutí. Politikou ověřování ve výrobě by mělo být také kontrolováno řetězení certifikátů, období platnosti, stav revokace, očekávaná identita, použití klíče a případné požadavky na důvěryhodnou časovou značku.

**Co se stane, když certifikát vyprší?**

Vypršení certifikátu nemění bajty prezentace, ale ovlivňuje hodnocení důvěry v certifikát. Zda podpis zůstane přijatelný, závisí na vaší politice a na tom, zda důvěryhodná časová značka prokazuje, že podepsání proběhlo během platnosti certifikátu. Nespoléhejte se jen na zobrazený čas podpisu jako na důvěryhodnou časovou značku.

**Může být podepsaná prezentace stále upravována?**

Ano. Podepsání soubor neuzamkne. Úprava podepsaného obsahu obvykle způsobí neplatnost existujícího podpisu, takže nejprve dokončete prezentaci a podepište finální revizi.

**Může prezentace obsahovat více než jeden podpis?**

Ano. Přidejte každý podpis do [Presentation.digital_signatures](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/digital_signatures/) před uložením. Během ověřování prohlédněte každý podpis a potvrďte, že jsou přítomni všichni požadovaní podepisující.

**Které formáty prezentací podporují tyto operace?**

Aspose.Slides podporuje operace s digitálními podpisy popsané zde pouze pro formát PPTX. Formáty PPT a OpenDocument nejsou touto API podporovány.

**Mohu odstranit podpis, aniž by to ovlivnilo snímky?**

Ano. Můžete odstranit jeden podpis nebo vyprázdnit celou kolekci a poté prezentaci uložit. Obsah snímků zůstane dostupný, ale uložený soubor již neobsahuje důkaz o odebraném podpisu.