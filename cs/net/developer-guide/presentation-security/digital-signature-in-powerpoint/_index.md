---
title: Přidání digitálních podpisů do prezentací v .NET
linktitle: Digitální podpis
type: docs
weight: 10
url: /cs/net/digital-signature-in-powerpoint/
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
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak podepsat existující PPTX prezentace pomocí PFX certifikátů a použít Aspose.Slides pro .NET k ověření nebo odstranění digitálních podpisů."
---
## **Přehled**

Digitální podpis pomáhá příjemci určit, kdo prezentaci podepsal a zda se podepsaný obsah změnil. Tři související bezpečnostní pojmy jsou zde důležité:

- **Digitální certifikát** je elektronické oprávnění, které spojuje identitu s veřejným klíčem. Důvěryhodná certifikační autorita (CA) může certifikát vydat, nebo organizace může použít samopodepsaný certifikát pro interní workflow.
- **Digitální podpis** je vytvořen z obsahu prezentace a soukromého klíče držitele certifikátu. Veřejný klíč certifikátu pak lze použít k ověření podpisu. Podpis poskytuje důkaz o původu a integritě; nešifruje prezentaci.
- **Ochrana heslem** řídí, zda uživatel může prezentaci otevřít nebo upravit. Je oddělena od digitálního podepisování a je popsaná v [Prezentace chráněné heslem](/slides/cs/net/password-protected-presentation/).

PowerPoint nabízí příkaz **Add a Digital Signature** pod **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

Po otevření podepsané prezentace může PowerPoint zobrazit oznámení o stavu podpisu.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides vystavuje podpisy přes [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/digitalsignatures/), [IDigitalSignatureCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/idigitalsignaturecollection/) jejíž položky implementují [IDigitalSignature](https://reference.aspose.com/slides/cs/net/aspose.slides/idigitalsignature/). Prezentace může obsahovat více podpisů.

## **Pochopení PFX certifikátů a hesel**

Soubor PFX, také známý jako PKCS#12 soubor a běžně s příponou `.pfx` nebo `.p12`, může obsahovat certifikát X.509, jeho soukromý klíč a řetězec certifikátů. Soukromý klíč umožňuje držiteli vytvořit podpis. Certifikát bez přístupného soukromého klíče nelze použít k podepsání prezentace.

Heslo PFX chrání balíček certifikátu a soukromý klíč. **Není** to heslo pro otevření nebo úpravu prezentace. Neskladujte soubory PFX ani jejich hesla ve zdrojovém řízení. Ve výrobě omezte přístup k souboru certifikátu a heslo získejte z úložiště tajemství nebo jiného chráněného konfiguračního zdroje. Níže uvedené příklady používají proměnnou prostředí pouze k vyhnutí se vložení hesla do kódu.

## **Přidání digitálního podpisu do prezentace**

Pro podepsání reálného workflow načtěte existující soubor PPTX, vytvořte [DigitalSignature](https://reference.aspose.com/slides/cs/net/aspose.slides/digitalsignature/) z PFX certifikátu a jeho hesla, přidejte podpis do kolekce prezentace a uložte do souboru PPTX.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var certificatePassword = Environment.GetEnvironmentVariable("PFX_PASSWORD")
    ?? throw new InvalidOperationException("Set the PFX_PASSWORD environment variable.");

using var presentation = new Presentation("InputPresentation.pptx");

var signature = new DigitalSignature("signing-certificate.pfx", certificatePassword)
{
    Comments = "Approved for release."
};

presentation.DigitalSignatures.Add(signature);
presentation.Save("InputPresentation-signed.pptx", SaveFormat.Pptx);
```

Uložení výsledku pod novým názvem zachová neoznačený zdrojový soubor. Hodnota [DigitalSignature.Comments](https://reference.aspose.com/slides/cs/net/aspose.slides/digitalsignature/comments/) popisuje účel podpisu; nejde o bezpečnostní kontrolu.

## **Ověření digitálních podpisů**

Když načtete podepsaný soubor PPTX, prohlédněte každou položku v [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/digitalsignatures/). Vlastnost [IDigitalSignature.IsValid](https://reference.aspose.com/slides/cs/net/aspose.slides/idigitalsignature/isvalid/) ukazuje, zda je vložený podpis platný pro aktuální obsah prezentace.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("InputPresentation-signed.pptx");

var signatureCount = presentation.DigitalSignatures.Count;

if (signatureCount == 0)
{
    Console.WriteLine("The presentation does not contain digital signatures.");
}
else
{
    var allSignaturesAreValid = true;

    foreach (var signature in presentation.DigitalSignatures)
    {
        var signatureStatus = signature.IsValid ? "VALID" : "INVALID";
        var signerName = signature.Certificate.SubjectName.Name;

        Console.WriteLine(
            $"{signerName}, {signature.SignTime:yyyy-MM-dd HH:mm:ss} -- {signatureStatus}");

        allSignaturesAreValid &= signature.IsValid;
    }

    Console.WriteLine(allSignaturesAreValid
        ? "All embedded signatures are valid for the current presentation."
        : "At least one embedded signature is invalid.");
}
```

Neplatný výsledek obvykle znamená, že se po podepsání změnil obsah prezentace nebo data podpisu, nebo že soubor je poškozený. Odebrání všech podpisů vytvoří neoznačenou prezentaci, takže kontrola pouze platnosti položek není dostačující: workflow citlivé na bezpečnost musí také ověřit, že je přítomen očekávaný počet podpisů a očekávané identity podepisujících.

Tento výsledek by neměl být považován za kompletní rozhodnutí o důvěře k certifikátu. V závislosti na vaší bezpečnostní politice může vaše aplikace také potřebovat vytvořit a ověřit řetězec certifikátů X.509, zkontrolovat platnost certifikátu a stav revokace, potvrdit očekávaný subjekt nebo otisk, ověřit využití klíče a zhodnotit důvěryhodný časový razítko. Hodnota [IDigitalSignature.SignTime](https://reference.aspose.com/slides/cs/net/aspose.slides/idigitalsignature/signtime/) sama o sobě není důkazem od důvěryhodné autority časových razítek.

## **Odstranění digitálních podpisů**

Odstranění podpisů mění stav zabezpečení prezentace. Následující příklad načte podepsaný soubor PPTX, odebere všechny podpisy pomocí [IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/cs/net/aspose.slides/idigitalsignaturecollection/clear/), a uloží neoznačenou kopii.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

Pro odebrání jen jednoho podpisu zavolejte [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/cs/net/aspose.slides/idigitalsignaturecollection/removeat/) s jeho nulovým indexem. Uložte do nového souboru, pokud nepřepisujete podepsaný originál jako explicitní část workflow.

## **Úvahy o úpravách a formátech**

- Podpis neznamená, že je prezentace jen pro čtení. Uživatelé i aplikace mohou soubor nadále upravovat, ale změny podepsaného obsahu obvykle zneplatní existující podpis.
- Proveďte všechny zamýšlené úpravy před podepsáním. Pokud je nutné prezentaci změnit, uložte revidovanou verzi a podepište tuto revizi znovu.
- Uchovávejte finální výstup ve formátu PPTX. Převod podepsané prezentace do jiného formátu nepřenáší původní PPTX podpis jako platný podpis pro převedený soubor.
- Zacházejte se soukromým klíčem certifikátu jako citlivým. Kdokoli, kdo získá soukromý klíč a jeho heslo, může vytvořit podpisy, které se jeví jako pocházející od držitele certifikátu.
- Uchovejte neoznačený zdroj nebo jinou kontrolovanou kopii, pokud to vyžaduje vaše politika archivace dokumentů.

## **Často kladené otázky**

**Zda digitální podpis šifruje prezentaci?**

Ne. Digitální podpis poskytuje důkaz o původu a integritě, ale obsah prezentace zůstává čitelný, pokud není použita samostatná šifrování. Použijte [ochranu heslem](/slides/cs/net/password-protected-presentation/), pokud má být přístup k obsahu omezen.

**Je heslo PFX stejné jako heslo prezentace?**

Ne. Heslo PFX odemyká soukromý klíč uložený v balíčku certifikátu. Neřídí, kdo může otevřít nebo upravit soubor PPTX.

**Mohu použít samopodepsaný certifikát?**

Technicky lze použít samopodepsaný certifikát, pokud obsahuje přístupný soukromý klíč. Příjemci jej nebudou automaticky důvěřovat, pokud není tento certifikát výslovně přidán do jejich důvěryhodného prostředí. Ve veřejných nebo meziorganičních workflow se obvykle používá certifikát vydaný důvěryhodnou CA.

**Co způsobí, že je podpis neplatný?**

Změna podepsaného obsahu prezentace nebo dat podpisu po podepsání může podpis neplatit. Poškození souboru může také způsobit selhání ověření. Pokud jsou všechny podpisy odstraněny, prezentace je neoznačená, nikoli soubor s neplatným podpisem.

**Znamená platný podpis, že mám důvěřovat podepisujícímu?**

Ne samostatně. Integrita podpisu a důvěra k podepisujícímu jsou oddělená rozhodnutí. Produkční politika ověřování by měla také kontrolovat řetězec certifikátů, dobu platnosti, stav revokace, očekávanou identitu, využití klíče a jakékoli požadavky na důvěryhodné časové razítko.

**Co se stane, když certifikát vyprší?**

Vypršení certifikátu nemění bajty prezentace, ale ovlivňuje hodnocení důvěry k certifikátu. Zda podpis zůstane přijatelný závisí na vaší politice a na tom, zda platné důvěryhodné časové razítko prokazuje, že podepsání proběhlo, když byl certifikát stále platný. Nespoléhejte se pouze na zobrazený čas podpisu jako na důvěryhodné časové razítko.

**Může být podepsaná prezentace stále upravována?**

Ano. Podepsání soubor neuzamkne. Úprava podepsaného obsahu obvykle zneplatní existující podpis, takže nejprve dokončete prezentaci a pak podepište finální revizi.

**Může prezentace obsahovat více než jeden podpis?**

Ano. Přidejte každý podpis do [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/digitalsignatures/) před uložením. Během ověřování prohlédněte každý podpis a potvrďte, že jsou přítomni všichni požadovaní podepisující.

**Které formáty prezentací podporují tyto operace?**

Aspose.Slides podporuje operace digitálního podpisu popsané zde pouze pro PPTX. Formáty PPT a OpenDocument nejsou tímto API workflow podporovány.

**Mohu odstranit podpis, aniž by to ovlivnilo snímky?**

Ano. Můžete odstranit jeden podpis nebo vyprázdnit celou kolekci a pak prezentaci uložit. Obsah snímků zůstane zachován, ale uložený soubor již neobsahuje důkaz o odstraněném podpisu.