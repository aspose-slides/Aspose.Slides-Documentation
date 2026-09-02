---
title: Přidání digitálních podpisů k prezentacím v C++
linktitle: Digitální podpis
type: docs
weight: 10
url: /cs/cpp/digital-signature-in-powerpoint/
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
- C++
- Aspose.Slides
description: "Naučte se, jak podepsat existující PPTX prezentace pomocí PFX certifikátů a použít Aspose.Slides pro C++ k ověření nebo odstranění digitálních podpisů."
---
## **Přehled**

Digitální podpis pomáhá příjemci určit, kdo prezentaci podepsal a zda se podepsaný obsah změnil. Tři související bezpečnostní koncepty jsou zde důležité:

- **Digitální certifikát** je elektronické pověření, které spojuje identitu s veřejným klíčem. Důvěryhodná certifikační autorita (CA) může certifikát vydat, nebo organizace může pro interní workflow použít samopodepsaný certifikát.
- **Digitální podpis** se vytvoří z obsahu prezentace a soukromého klíče držitele certifikátu. Veřejný klíč certifikátu lze poté použít k ověření podpisu. Podpis poskytuje důkaz o původu a integritě; nešifruje prezentaci.
- **Ochrana heslem** řídí, zda uživatel může prezentaci otevřít nebo upravit. Je oddělena od digitálního podepisování a je popsána v [Prezentace chráněné heslem](/cpp/password-protected-presentation/).

PowerPoint nabízí příkaz **Add a Digital Signature** pod **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

Po otevření podepsané prezentace může PowerPoint zobrazit upozornění o stavu podpisu.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides zpřístupňuje podpisy přes [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/get_digitalsignatures/), který vrací [IDigitalSignatureCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idigitalsignaturecollection/) obsahující položky implementující [IDigitalSignature](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idigitalsignature/). Prezentace může obsahovat více podpisů.

## **Pochopení PFX certifikátů a hesel**

Soubor PFX, také známý jako PKCS#12 a běžně s příponou `.pfx` nebo `.p12`, může obsahovat X.509 certifikát, jeho soukromý klíč a řetězec certifikátů. Soukromý klíč umožňuje jeho držiteli vytvořit podpis. Certifikát bez přístupného soukromého klíče nelze použít k podepsání prezentace.

Heslo PFX chrání balíček certifikátu a soukromý klíč. Není to heslo pro otevírání nebo úpravu prezentace. Neskladujte soubory PFX ani jejich hesla do verzovacího systému. V produkci omezte přístup k souboru certifikátu a získávejte jeho heslo z tajného úložiště nebo jiného chráněného zdroje konfigurace. Níže uvedené příklady používají proměnnou prostředí jen proto, aby se heslo neukládalo přímo v kódu.

## **Přidání digitálního podpisu do prezentace**

Pro podepisování reálného workflow načtěte existující soubor PPTX, vytvořte [DigitalSignature](https://reference.aspose.com/slides/cs/cpp/aspose.slides/digitalsignature/) z PFX certifikátu a jeho hesla, přidejte podpis do kolekce prezentace a uložte do souboru PPTX.

```cpp
auto certificatePassword = Environment::GetEnvironmentVariable(u"PFX_PASSWORD");
if (certificatePassword.IsNullOrEmpty())
{
    throw InvalidOperationException(u"Set the PFX_PASSWORD environment variable.");
}

auto presentation = MakeObject<Presentation>(u"InputPresentation.pptx");

auto signature = MakeObject<DigitalSignature>(u"signing-certificate.pfx", certificatePassword);
signature->set_Comments(u"Approved for release.");

presentation->get_DigitalSignatures()->Add(signature);
presentation->Save(u"InputPresentation-signed.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Uložení výsledku pod novým jménem zachová nepsaný zdrojový soubor. Hodnota [IDigitalSignature::set_Comments](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idigitalsignature/set_comments/) popisuje účel podpisu; není to bezpečnostní kontrola.

## **Ověření digitálních podpisů**

Když načtete podepsaný soubor PPTX, prozkoumejte každou položku vrácenou metodou [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/get_digitalsignatures/). Metoda [IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idigitalsignature/get_isvalid/) udává, zda je vložený podpis platný pro aktuální obsah prezentace.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

auto signatureCount = presentation->get_DigitalSignatures()->get_Count();

if (signatureCount == 0)
{
    Console::WriteLine(u"The presentation does not contain digital signatures.");
}
else
{
    bool allSignaturesAreValid = true;

    for (int signatureIndex = 0; signatureIndex < signatureCount; ++signatureIndex)
    {
        auto signature = presentation->get_DigitalSignature(signatureIndex);
        auto signatureIsValid = signature->get_IsValid();
        auto signatureStatus = signatureIsValid ? u"VALID" : u"INVALID";
        auto signerName = signature->get_Certificate()->get_SubjectName()->get_Name();
        auto signingTime = signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm:ss");

        Console::WriteLine(u"{0}, {1} -- {2}", signerName, signingTime, signatureStatus);

        allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"All embedded signatures are valid for the current presentation.");
    }
    else
    {
        Console::WriteLine(u"At least one embedded signature is invalid.");
    }
}

presentation->Dispose();
```

Neplatný výsledek obvykle znamená, že se po podpisu změnil obsah prezentace nebo data podpisu, nebo že je soubor poškozen. Odebrání všech podpisů vytvoří nepsanou prezentaci, takže kontrola pouze platnosti položek není dostatečná: bezpečnostně citlivý workflow musí také ověřit, že je přítomen očekávaný počet podpisů a očekávané identity podepisujících.

Tento výsledek by neměl být považován za kompletní rozhodnutí o důvěře v certifikát. V závislosti na vaší bezpečnostní politice může aplikace také potřebovat sestavit a ověřit řetězec X.509 certifikátů, zkontrolovat datum platnosti certifikátu a stav revokace, potvrdit očekávaný subjekt nebo otisk, ověřit použití klíče a vyhodnotit důvěryhodný časový razítko. Hodnota [IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idigitalsignature/get_signtime/) sama o sobě není důkazem od důvěryhodné autority časových razítek.

## **Odstranění digitálních podpisů**

Odstranění podpisů mění bezpečnostní stav prezentace. Následující příklad načte podepsaný soubor PPTX, odstraní všechny podpisy pomocí [IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idigitalsignaturecollection/clear/) a uloží nepsanou kopii.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Pro odstranění pouze jednoho podpisu zavolejte [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idigitalsignaturecollection/removeat/) s jeho nulovým indexem. Uložte do nového souboru, pokud není přepisování původního podepsaného souboru explicitní součástí vašeho workflow.

## **Úpravy a úvahy o formátu**

- Podpis neznamená, že je prezentace pouze pro čtení. Uživatelé a aplikace mohou soubor stále upravovat, ale změny podepsaného obsahu obvykle neplatný existující podpis.
- Proveďte všechny zamýšlené úpravy před podepsáním. Pokud je nutné prezentaci změnit, uložte upravenou verzi a podepište ji znovu.
- Uchovávejte finální výstup ve formátu PPTX. Převod podepsané prezentace do jiného formátu nepřenáší původní PPTX podpis jako platný podpis pro převedený soubor.
- Považujte soukromý klíč certifikátu za citlivý. Kdokoli získá soukromý klíč a jeho heslo může vytvářet podpisy, které se jeví jako pocházející od držitele certifikátu.
- Zachovejte nepsaný zdroj nebo další kontrolovanou kopii, pokud to vyžaduje vaše politika archivace dokumentů.

## **Často kladené otázky**

**Šifruje digitální podpis prezentaci?**

Ne. Digitální podpis poskytuje důkaz o původu a integritě, ale obsah prezentace zůstává čitelný, pokud není použita samostatná šifrování. Pro omezení přístupu k obsahu použijte [ochranu heslem](/cpp/password-protected-presentation/).

**Je heslo PFX stejné jako heslo prezentace?**

Ne. Heslo PFX odemyká soukromý klíč uložený v balíčku certifikátu. Neřídí, kdo může otevřít nebo editovat soubor PPTX.

**Mohu použít samopodepsaný certifikát?**

Technicky ano, pokud obsahuje přístupný soukromý klíč. Příjemci jej nebudou automaticky důvěřovat, pokud není explicitně přidán do jejich důvěryhodného prostředí. Veřejné nebo mezi‑organizační workflow obvykle používají certifikát vydaný důvěryhodnou CA.

**Co způsobuje, že je podpis neplatný?**

Změna podepsaného obsahu prezentace nebo dat podpisu po podpisu může podpis neplatit. Poškození souboru také může způsobit selhání ověření. Pokud jsou všechny podpisy odstraněny, prezentace je nepsaná, nikoli soubor s neplatným podpisem.

**Znamená platný podpis, že mám důvěřovat podepisujícímu?**

Ne samotný. Integrita podpisu a důvěra v podepisujícího jsou oddělená rozhodnutí. Produkční politika ověřování by měla také kontrolovat řetězec certifikátů, období platnosti, stav revokace, očekávanou identitu, použití klíče a případné požadavky na důvěryhodné časové razítko.

**Co se stane, když certifikát vyprší?**

Vypršení certifikátu nemění bajty prezentace, ale ovlivňuje hodnocení důvěry v certifikát. Zda je podpis stále přijatelný, závisí na vaší politice a na tom, zda existuje platné důvěryhodné časové razítko dokazující, že podpis byl vytvořen během platnosti certifikátu. Nespoléhejte se jen na zobrazený čas podpisu jako na důvěryhodné časové razítko.

**Může být podepsaná prezentace i nadále upravována?**

Ano. Podepsání neblokuje soubor. Úprava podepsaného obsahu obecně způsobí neplatnost existujícího podpisu, proto dokončete prezentaci před podpisem finální revize.

**Může prezentace obsahovat více než jeden podpis?**

Ano. Přidejte každý podpis do kolekce vrácené metodou [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/get_digitalsignatures/) před uložením. Během ověřování kontrolujte každý podpis a potvrďte, že jsou přítomni všichni požadovaní podepisující.

**Které formáty prezentací podporují tyto operace?**

Aspose.Slides podporuje operace s digitálními podpisy popsané zde pouze pro PPTX. Formáty PPT a OpenDocument nejsou tímto API workflow podporovány.

**Mohu odstranit podpis, aniž by to ovlivnilo snímky?**

Ano. Můžete odstranit jeden podpis nebo vyprázdnit celou kolekci a pak uložit prezentaci. Obsah snímků zůstane zachován, ale uložený soubor již neobsahuje důkazy o odstraněném podpisu.