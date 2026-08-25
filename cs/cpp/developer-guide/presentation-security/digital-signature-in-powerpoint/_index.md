---
title: Přidání digitálních podpisů do prezentací v C++
linktitle: Digitální podpis
type: docs
weight: 10
url: /cs/cpp/digital-signature-in-powerpoint/
keywords:
- digitální podpis
- digitální certifikát
- certifikační autorita
- certifikát PFX
- PKCS#12
- ověřit podpis
- PowerPoint
- PPTX
- bezpečnost prezentace
- C++
- Aspose.Slides
description: "Zjistěte, jak podepsat existující PPTX prezentace pomocí certifikátů PFX a použít Aspose.Slides pro C++ k ověření nebo odstranění digitálních podpisů."
---
## **Přehled**

Digitální podpis umožňuje příjemci zjistit, kdo prezentaci podepsal a zda se podepsaný obsah změnil. Důležité jsou zde tři související bezpečnostní koncepty:

- **Digitální certifikát** je elektronické oprávnění, které spojuje identitu s veřejným klíčem. Důvěryhodná certifikační autorita (CA) může certifikát vydat, nebo organizace může pro interní workflow použít samopodepsaný certifikát.
- **Digitální podpis** se vytváří z obsahu prezentace a soukromého klíče držitele certifikátu. Veřejný klíč certifikátu lze poté použít k ověření podpisu. Podpis poskytuje důkaz o původu a integritě; nešifruje prezentaci.
- **Ochrana heslem** řídí, zda může uživatel otevřít nebo upravit prezentaci. Je oddělená od digitálního podepisování a je popsána v [Password-Protected Presentations](/slides/cs/cpp/password-protected-presentation/).

PowerPoint poskytuje příkaz **Add a Digital Signature** pod **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

Po otevření podepsané prezentace může PowerPoint zobrazit oznámení o stavu podpisu.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides vystavuje podpisy přes [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/get_digitalsignatures/), který vrací [IDigitalSignatureCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idigitalsignaturecollection/) obsahující položky implementující [IDigitalSignature](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idigitalsignature/). Prezentace může obsahovat více podpisů.

## **Pochopení certifikátů PFX a hesel**

Soubor PFX, známý také jako soubor PKCS#12 a běžně s příponou `.pfx` nebo `.p12`, může obsahovat X.509 certifikát, jeho soukromý klíč a řetězec certifikátů. Soukromý klíč umožňuje držiteli vytvořit podpis. Certifikát bez přístupného soukromého klíče nelze použít k podepsání prezentace.

Heslo PFX chrání balíček certifikátu a soukromý klíč. Není to heslo pro otevírání nebo úpravu prezentace. Nezveřejňujte soubory PFX ani jejich hesla ve správě zdrojového kódu. V produkci omezte přístup k souboru certifikátu a jeho heslo získejte z tajného úložiště nebo jiného chráněného zdroje konfigurace. Níže uvedené příklady používají proměnnou prostředí jen proto, aby se heslo neukládalo přímo v kódu.

## **Přidání digitálního podpisu do prezentace**

Pro podepsání skutečného workflow načtěte existující soubor PPTX, vytvořte [DigitalSignature](https://reference.aspose.com/slides/cs/cpp/aspose.slides/digitalsignature/) z PFX certifikátu a jeho hesla, přidejte podpis do kolekce prezentace a uložte do souboru PPTX.

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

Uložení výsledku pod novým názvem zachová nepodepsaný zdrojový soubor. Hodnota [IDigitalSignature::set_Comments](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idigitalsignature/set_comments/) popisuje účel podpisu; nejde o bezpečnostní kontrolu.

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

Neplatný výsledek obvykle znamená, že se po podepsání změnil obsah prezentace nebo data podpisu, nebo že soubor je poškozený. Odebrání všech podpisů vytvoří nepodepsanou prezentaci, takže kontrola pouze platnosti položek nestačí: workflow citlivé na bezpečnost musí také ověřit, že je přítomen očekávaný počet podpisů a správné identity podepisujících.

Tento výsledek validace by neměl být považován za kompletní rozhodnutí o důvěře v certifikát. Podle vaší bezpečnostní politiky může aplikace také potřebovat vytvořit a ověřit řetězec X.509 certifikátů, zkontrolovat data platnosti certifikátu a stav odvolání, potvrdit očekávaný subjekt nebo otisk, ověřit použití klíče a vyhodnotit důvěryhodné časové razítko. Hodnota [IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idigitalsignature/get_signtime/) sama o sobě není důkazem od důvěryhodné autority časových razítek.

## **Odstranění digitálních podpisů**

Odstranění podpisů mění bezpečnostní stav prezentace. Následující příklad načte podepsaný soubor PPTX, odstraní všechny podpisy pomocí [IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idigitalsignaturecollection/clear/), a uloží nepodepsanou kopii.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Pro odstranění jen jednoho podpisu zavolejte [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idigitalsignaturecollection/removeat/) s jeho nulovým indexem. Uložte do nového souboru, pokud přepisování původního podepsaného souboru není explicitní součástí vašeho workflow.

## **Úpravy a úvahy o formátu**

- Podpis neznamená, že je prezentace jen pro čtení. Uživatelé a aplikace mohou soubor stále upravovat, ale změny podepsaného obsahu obvykle zneplatní existující podpis.
- Dokončete všechny zamýšlené úpravy před podepsáním. Pokud je třeba prezentaci změnit, uložte upravenou verzi a podepište ji znovu.
- Výstup ponechte v formátu PPTX. Převod podepsané prezentace do jiného formátu nepřenáší původní PPTX podpis jako platný podpis pro konvertovaný soubor.
- Považujte soukromý klíč certifikátu za citlivý. Kdokoli, kdo získá soukromý klíč a jeho heslo, může vytvářet podpisy, které se jeví jako pocházející od držitele certifikátu.
- Uchovávejte nepodepsaný zdroj nebo jinou kontrolovanou kopii, pokud to vyžaduje vaše politika archivace dokumentů.

## **Často kladené otázky**

**Zda digitální podpis šifruje prezentaci?**

Ne. Digitální podpis poskytuje důkaz o původu a integritě, ale obsah prezentace zůstává čitelný, pokud není použita samostatná šifrování. Použijte [password protection](/slides/cs/cpp/password-protected-presentation/), když je nutné omezit přístup k obsahu.

**Je heslo PFX stejné jako heslo prezentace?**

Ne. Heslo PFX odemyká soukromý klíč uložený v balíčku certifikátu. Nekontroluje, kdo může otevřít nebo upravit soubor PPTX.

**Mohu použít samopodepsaný certifikát?**

Technicky lze použít samopodepsaný certifikát, pokud obsahuje přístupný soukromý klíč. Příjemci jej automaticky nedůvěřují, pokud nebyl explicitně přidán do jejich důvěryhodného prostředí. Ve veřejných nebo meziorganizačních workflow se obvykle používá certifikát vydaný důvěryhodnou CA.

**Co způsobuje, že je podpis neplatný?**

Změna podepsaného obsahu prezentace nebo dat podpisu po podepsání může podpis neplatnit. Poškození souboru také může způsobit selhání validace. Pokud jsou všechny podpisy odstraněny, prezentace je nepodepsaná, nikoli soubor s neplatným podpisem.

**Znamená platný podpis, že mám důvěřovat podepisujícímu?**

Ne samotný. Integrita podpisu a důvěra v podepisujícího jsou samostatná rozhodnutí. Produkční validační politika by také měla kontrolovat řetězec certifikátů, období platnosti, stav odvolání, očekávanou identitu, použití klíče a případné požadavky na důvěryhodné časové razítko.

**Co se stane, když certifikát vyprší?**

Vypršení certifikátu nemění bajty prezentace, ale ovlivňuje hodnocení důvěry v certifikát. Zda zůstane podpis přijatelný, závisí na vaší politice a na tom, zda platné důvěryhodné časové razítko prokazuje, že podepsání proběhlo během platnosti certifikátu. Nespoléhejte se pouze na zobrazený čas podpisu jako na důvěryhodné časové razítko.

**Může být podepsaná prezentace stále upravována?**

Ano. Podepsání soubor nezamkne. Úprava podepsaného obsahu obvykle zneplatní existující podpis, takže nejprve dokončete prezentaci a poté podepište finální revizi.

**Může prezentace obsahovat více než jeden podpis?**

Ano. Přidejte každý podpis do kolekce vrácené metodou [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/get_digitalsignatures/) před uložením. Během validace prostudujte každý podpis a potvrďte, že jsou přítomni všichni požadovaní podepisující.

**Které formáty prezentací podporují tyto operace?**

Aspose.Slides podporuje operace s digitálními podpisy popsané zde pouze pro PPTX. Formáty PPT a OpenDocument nejsou tímto API workflow podporovány.

**Mohu odstranit podpis, aniž by to ovlivnilo snímky?**

Ano. Můžete odstranit jeden podpis nebo vyprázdnit celou kolekci a poté prezentaci uložit. Obsah snímků zůstane zachován, ale uložený soubor již neobsahuje důkazy o odstraněném podpisu.