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
- certifikát PFX
- PKCS#12
- ověřit podpis
- PowerPoint
- PPTX
- zabezpečení prezentací
- Python
- Aspose.Slides
description: "Naučte se, jak podepsat existující PPTX prezentace pomocí certifikátů PFX a pomocí Aspose.Slides pro Python na platformě .NET ověřovat nebo odstraňovat digitální podpisy."
---
## **Přehled**

Digitální podpis pomáhá příjemci zjistit, kdo prezentaci podepsal a zda se podepsaný obsah změnil. Tři související bezpečnostní koncepty jsou zde důležité:

- **Digitální certifikát** je elektronické oprávnění, které spojuje identitu s veřejným klíčem. Důvěryhodná certifikační autorita (CA) může certifikát vydat, nebo organizace může pro interní workflow použít samopodepsaný certifikát.
- **Digitální podpis** se vytváří z obsahu prezentace a soukromého klíče držitele certifikátu. Veřejný klíč certifikátu lze pak použít k ověření podpisu. Podpis poskytuje důkaz o původu a integritě; nešifruje prezentaci.
- **Ochrana heslem** určuje, zda uživatel může prezentaci otevřít nebo upravit. Je oddělená od digitálního podepisování a je popsána v [Prezentace chráněné heslem](/slides/cs/python-net/password-protected-presentation/).

PowerPoint poskytuje příkaz **Add a Digital Signature** pod **File > Info > Protect Presentation**.

![Nabídka PowerPoint Protect Presentation s vyznačeným položkou Add a Digital Signature](add-digital-signature-in-powerpoint.png)

Po otevření podepsané prezentace může PowerPoint zobrazit oznámení o stavu podpisu.

![Oznámení PowerPoint uvádějící, že prezentace obsahuje platné podpisy](digital-signature-status-in-powerpoint.png)

Aspose.Slides zpřístupňuje podpisy prostřednictvím [Presentation.digital_signatures](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/digital_signatures/), kolekce [DigitalSignatureCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/digitalsignaturecollection/) jejíž položky jsou objekty [DigitalSignature](https://reference.aspose.com/slides/cs/python-net/aspose.slides/digitalsignature/). Prezentace může obsahovat více podpisů.

## **Pochopení certifikátů PFX a hesel**

Soubor PFX, také známý jako soubor PKCS#12 a běžně s příponou `.pfx` nebo `.p12`, může obsahovat certifikát X.509, jeho soukromý klíč a řetězec certifikátů. Soukromý klíč umožňuje držiteli vytvořit podpis. Certifikát bez přístupného soukromého klíče nelze použít k podepsání prezentace.

Password PFX chrání paket certifikátu a soukromý klíč. Není to **heslo** pro otevření nebo úpravu prezentace. Nepřidávejte soubory PFX ani jejich hesla do správy zdrojového kódu. V produkci omezte přístup k souboru certifikátu a získávejte jeho heslo z tajného úložiště nebo jiného chráněného zdroje konfigurace. Níže uvedené příklady používají proměnnou prostředí pouze proto, aby se heslo nevkládalo do kódu.

## **Přidání digitálního podpisu do prezentace**

K podepsání reálného workflow prezentace načtěte existující soubor PPTX, vytvořte [DigitalSignature](https://reference.aspose.com/slides/cs/python-net/aspose.slides/digitalsignature/) z PFX certifikátu a jeho hesla, přidejte podpis do kolekce v prezentaci a uložte do souboru PPTX.

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

Uložení výsledku pod novým názvem zachová ne‑podepsaný zdrojový soubor. Hodnota [DigitalSignature.comments](https://reference.aspose.com/slides/cs/python-net/aspose.slides/digitalsignature/comments/) popisuje účel podpisu; není to bezpečnostní kontrola.

## **Ověření digitálních podpisů**

Při načtení podepsaného souboru PPTX prohlédněte každou položku v [Presentation.digital_signatures](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/digital_signatures/). Vlastnost [DigitalSignature.is_valid](https://reference.aspose.com/slides/cs/python-net/aspose.slides/digitalsignature/is_valid/) udává, zda je vložený podpis platný pro aktuální obsah prezentace.

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

Neplatný výsledek obvykle znamená, že obsah podepsané prezentace nebo data podpisu se po podepsání změnily, nebo že soubor je poškozen. Odebrání všech podpisů vytvoří nepodepsanou prezentaci, takže kontrola pouze platnosti položek není dostačující: workflow citlivé na bezpečnost musí také ověřit, že je přítomen očekávaný počet podpisů a očekávané identity podepisujících.

[DigitalSignature.certificate](https://reference.aspose.com/slides/cs/python-net/aspose.slides/digitalsignature/certificate/) poskytuje data certifikátu jako pole bytů. Příklad vypočítá jeho SHA‑256 otisk, aby aplikace mohla porovnat s otiskem očekávaného certifikátu podepisujícího.

Tento výsledek platnosti by neměl být považován za úplné rozhodnutí o důvěře v certifikát. V závislosti na vaší bezpečnostní politice může vaše aplikace také potřebovat vytvořit a ověřit řetězec certifikátů X.509, zkontrolovat datum platnosti certifikátu a stav odvolání, potvrdit očekávaný subjekt nebo otisk, ověřit použití klíče a vyhodnotit důvěryhodné časové razítko. Hodnota [DigitalSignature.sign_time](https://reference.aspose.com/slides/cs/python-net/aspose.slides/digitalsignature/sign_time/) sama o sobě není důkaz od důvěryhodné autority časových razítek.

## **Odstranění digitálních podpisů**

Odebrání podpisů mění bezpečnostní stav prezentace. Následující příklad načte podepsaný soubor PPTX, odebere všechny podpisy pomocí [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/cs/python-net/aspose.slides/digitalsignaturecollection/clear/), a uloží ne‑podepsanou kopii.

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

Pro odebrání pouze jednoho podpisu zavolejte [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/cs/python-net/aspose.slides/digitalsignaturecollection/remove_at/) s jeho indexem počínajícím nulou. Uložte do nového souboru, pokud není přepisování původního podepsaného souboru explicitní součástí vašeho workflow.

## **Úvahy o úpravách a formátu**

- Podpis neznamená, že je prezentace pouze pro čtení. Uživatelé a aplikace mohou soubor i nadále upravovat, ale změny podepsaného obsahu obvykle zneplatní existující podpis.
- Proveďte všechny zamýšlené úpravy před podepsáním. Pokud je nutné prezentaci změnit, uložte opravenou verzi a podepište ji znovu.
- Uchovávejte finální výstup ve formátu PPTX. Převod podepsané prezentace do jiného formátu nepřenese původní PPTX podpis jako platný podpis pro konvertovaný soubor.
- Považujte soukromý klíč certifikátu za citlivý. Kdokoli, kdo získá soukromý klíč a jeho heslo, může vytvořit podpisy, jež se jeví jako pocházející od držitele certifikátu.
- Uchovávejte ne‑podepsaný zdroj nebo jinou kontrolovanou kopii, pokud to vyžaduje vaše politika uchovávání dokumentů.

## **Často kladené otázky**

**Šifruje digitální podpis prezentaci?**

Ne. Digitální podpis poskytuje důkaz o původu a integritě, ale obsah prezentace zůstává čitelný, pokud není aplikováno samostatné šifrování. Použijte [ochranu heslem](/slides/cs/python-net/password-protected-presentation/), pokud je nutné omezit přístup k obsahu.

**Je heslo PFX stejné jako heslo prezentace?**

Ne. Heslo PFX odemyká soukromý klíč uložený v balíčku certifikátu. Není to heslo, které řídí, kdo může otevřít nebo upravit soubor PPTX.

**Mohu použít samopodepsaný certifikát?**

Technicky lze použít samopodepsaný certifikát, pokud obsahuje přístupný soukromý klíč. Příjemci mu však nebudou automaticky důvěřovat, pokud nebyl tento certifikát výslovně přidán do jejich důvěryhodného prostředí. Veřejné nebo meziorganizační workflow obecně používají certifikát vydaný důvěryhodnou certifikační autoritou.

**Co způsobí, že je podpis neplatný?**

Změna obsahu podepsané prezentace nebo dat podpisu po podepsání může podpis neplatným učinit. Poškození souboru může také vést k selhání ověření. Pokud jsou odebrány všechny podpisy, prezentace je nepodepsaná, nikoli soubor obsahující neplatný podpis.

**Znamená platný podpis, že bych měl důvěřovat podepisujícímu?**

Ne, samostatně. Integrita podpisu a důvěra v podepisující jsou samostatná rozhodnutí. Politika výroby by také měla kontrolovat řetězec certifikátů, období platnosti, stav odvolání, očekávanou identitu, použití klíče a případné požadavky na důvěryhodné časové razítko.

**Co se stane, když certifikát vyprší?**

Vypršení certifikátu nemění bajty prezentace, ale ovlivňuje hodnocení důvěry v certifikát. Zda podpis zůstane přijatelné, závisí na vaší politice a na tom, zda platné důvěryhodné časové razítko prokazuje, že podepsání proběhlo během platnosti certifikátu. Nespoléhejte se jen na zobrazený čas podpisu jako na důvěryhodné časové razítko.

**Může být podepsaná prezentace stále upravena?**

Ano. Podepsání soubor neuzamkne. Úprava podepsaného obsahu obvykle zneplatní existující podpis, proto dokončete prezentaci nejprve a podepište finální revizi.

**Může prezentace obsahovat více než jeden podpis?**

Ano. Přidejte každý podpis do [Presentation.digital_signatures](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/digital_signatures/) před uložením. Během ověřování prohlédněte každý podpis a potvrďte, že jsou přítomni všichni požadovaní podepisující.

**Které formáty prezentací podporují tyto operace?**

Aspose.Slides podporuje operace s digitálním podpisem popsané zde pouze pro PPTX. Formáty PPT a OpenDocument prezentace nejsou tímto API workflow podporovány.

**Mohu odstranit podpis, aniž by to ovlivnilo snímky?**

Ano. Můžete odstranit jeden podpis nebo vymazat celou kolekci a poté uložit prezentaci. Obsah snímků zůstane dostupný, ale uložený soubor již neobsahuje důkaz o odstraněném podpisu.