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
- certifikát PFX
- PKCS#12
- ověřit podpis
- PowerPoint
- PPTX
- bezpečnost prezentací
- .NET
- C#
- Aspose.Slides
description: "Zjistěte, jak podepsat existující PPTX prezentace pomocí certifikátů PFX a použít Aspose.Slides pro .NET k ověření nebo odstranění digitálních podpisů."
---
## **Přehled**

Digitální podpis pomáhá příjemci určit, kdo prezentaci podepsal a zda se podepsaný obsah změnil. Tři související bezpečnostní pojmy jsou zde důležité:

- **digitální certifikát** je elektronické oprávnění, které spojuje identitu s veřejným klíčem. Důvěryhodná certifikační autorita (CA) může certifikát vydat, nebo organizace může použít samopodepsaný certifikát pro interní workflow.
- **digitální podpis** je vytvořen z obsahu prezentace a soukromého klíče držitele certifikátu. Veřejný klíč certifikátu může být následně použit k ověření podpisu. Podpis poskytuje důkaz o původu a integritě; nešifruje prezentaci.
- **ochrana heslem** řídí, zda uživatel může otevřít nebo upravit prezentaci. Je oddělená od digitálního podepisování a je popsána v [Prezentace chráněné heslem](/net/password-protected-presentation/).

PowerPoint poskytuje příkaz **Add a Digital Signature** v nabídce **File > Info > Protect Presentation**.

![Nabídka PowerPoint Protect Presentation se zvýrazněným příkazem Add a Digital Signature](add-digital-signature-in-powerpoint.png)

Po otevření podepsané prezentace může PowerPoint zobrazit oznámení o stavu podpisu.

![Upozornění PowerPoint, že prezentace obsahuje platné podpisy](digital-signature-status-in-powerpoint.png)

Aspose.Slides zpřístupňuje podpisy prostřednictvím [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/digitalsignatures/), [IDigitalSignatureCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/idigitalsignaturecollection/), jejíž položky implementují [IDigitalSignature](https://reference.aspose.com/slides/cs/net/aspose.slides/idigitalsignature/). Prezentace může obsahovat více podpisů.

## **Pochopení certifikátů PFX a hesel**

Soubor PFX, také známý jako soubor PKCS#12 a obvykle s příponou `.pfx` nebo `.p12`, může obsahovat certifikát X.509, jeho soukromý klíč a řetězec certifikátů. Soukromý klíč umožňuje jeho držiteli vytvořit podpis. Certifikát bez přístupného soukromého klíče nelze použít k podepsání prezentace.

Heslo PFX chrání balíček certifikátu a soukromý klíč. Není **heslem** pro otevření nebo úpravu prezentace. Nezapisujte soubory PFX ani jejich hesla do systému pro správu zdrojového kódu. Ve výrobním prostředí omezte přístup k souboru certifikátu a získávejte jeho heslo ze zabezpečeného úložiště nebo jiného chráněného konfiguračního zdroje. Níže uvedené příklady používají proměnnou prostředí jen proto, aby se heslo nezakódovalo přímo v kódu.

## **Přidání digitálního podpisu do prezentace**

Pro podepsání reálného workflow prezentace načtěte existující soubor PPTX, vytvořte [DigitalSignature](https://reference.aspose.com/slides/cs/net/aspose.slides/digitalsignature/) z PFX certifikátu a jeho hesla, přidejte podpis do kolekce prezentace a uložte do souboru PPTX.

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

Uložení výsledku pod novým názvem zachová neoznačený zdrojový soubor. Hodnota [DigitalSignature.Comments](https://reference.aspose.com/slides/cs/net/aspose.slides/digitalsignature/comments/) popisuje účel podpisu; není to bezpečnostní kontrola.

## **Ověření digitálních podpisů**

Když načtete podepsaný soubor PPTX, prohlédněte každou položku v [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/digitalsignatures/). Vlastnost [IDigitalSignature.IsValid](https://reference.aspose.com/slides/cs/net/aspose.slides/idigitalsignature/isvalid/) udává, zda je vložený podpis platný pro aktuální obsah prezentace.

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

Neplatný výsledek obvykle znamená, že se po podepsání změnil obsah prezentace nebo data podpisu, nebo že je soubor poškozen. Odstranění všech podpisů vytvoří neoznačenou prezentaci, takže kontrola pouze platnosti položek není dostačující: workflow citlivé na bezpečnost musí také ověřit, že je přítomen očekávaný počet podpisů a očekávané identity podepisujících.

Tento výsledek platnosti by neměl být považován za úplné rozhodnutí o důvěře v certifikát. V závislosti na vaší bezpečnostní politice může vaše aplikace také potřebovat vytvořit a ověřit řetězec certifikátů X.509, zkontrolovat data platnosti certifikátu a stav revokace, potvrdit očekávaný subjekt nebo otisk, ověřit využití klíče a vyhodnotit důvěryhodné časové razítko. Hodnota [IDigitalSignature.SignTime](https://reference.aspose.com/slides/cs/net/aspose.slides/idigitalsignature/signtime/) sama o sobě není důkaz od důvěryhodné autority časových razítek.

## **Odstranění digitálních podpisů**

Odstranění podpisů mění bezpečnostní stav prezentace. Následující příklad načte podepsaný soubor PPTX, odstraní všechny podpisy pomocí [IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/cs/net/aspose.slides/idigitalsignaturecollection/clear/), a uloží neoznačenou kopii.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

Pro odstranění pouze jednoho podpisu zavolejte [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/cs/net/aspose.slides/idigitalsignaturecollection/removeat/) s nulovým indexem. Uložte do nového souboru, pokud není přepisování původního podepsaného souboru explicitní součástí vašeho workflow.

## **Úvahy o úpravách a formátech**

- Podpis neznamená, že je prezentace jen pro čtení. Uživatelé a aplikace mohou soubor i nadále upravovat, ale změny podepsaného obsahu obvykle neplatí existující podpis.
- Dokončete všechny zamýšlené úpravy před podepsáním. Pokud je nutné prezentaci změnit, uložte revidovanou verzi a zopakujte podepsání.
- Uchovávejte finální výstup ve formátu PPTX. Převod podepsané prezentace do jiného formátu nepřenáší původní PPTX podpis jako platný podpis pro převedený soubor.
- Zacházejte se soukromým klíčem certifikátu jako s citlivou informací. Každý, kdo získá soukromý klíč a jeho heslo, může vytvořit podpisy, které se jeví jako pocházející od držitele certifikátu.
- Uchovávejte neoznačený zdroj nebo jinou kontrolovanou kopii, pokud to vyžaduje vaše politika archivace dokumentů.

## **Často kladené otázky**

**Šifruje digitální podpis prezentaci?**

Ne. Digitální podpis poskytuje důkaz o původu a integritě, ale obsah prezentace zůstává čitelný, pokud není použita samostatná šifrování. Použijte [ochranu heslem](/net/password-protected-presentation/), když je třeba omezit přístup k obsahu.

**Je heslo PFX stejné jako heslo prezentace?**

Ne. Heslo PFX odemyká soukromý klíč uložený v balíčku certifikátu. Neurčuje, kdo může otevřít nebo upravit soubor PPTX.

**Mohu použít samopodepsaný certifikát?**

Technicky lze použít samopodepsaný certifikát, pokud obsahuje přístupný soukromý klíč. Příjemci jej však nebudou automaticky důvěřovat, pokud není tento certifikát explicitně přidán do jejich důvěryhodného prostředí. Ve veřejných nebo meziorganizačních workflow se obecně používá certifikát vydaný důvěryhodnou CA.

**Co způsobí, že je podpis neplatný?**

Změna podepsaného obsahu prezentace nebo dat podpisu po podepsání může podpis neplatit. Poškození souboru může také způsobit neúspěšnou validaci. Pokud jsou odstraněny všechny podpisy, prezentace je neoznačená, nikoli soubor obsahující neplatný podpis.

**Znamená platný podpis, že mám důvěřovat podepisujícímu?**

Ne samotný. Integrita podpisu a důvěra v podepisujícího jsou oddělená rozhodnutí. Politika ověřování ve výrobě by měla také kontrolovat řetězec certifikátů, období platnosti, stav revokace, očekávanou identitu, využití klíče a případné požadavky na důvěryhodné časové razítko.

**Co se stane, když certifikát vyprší?**

Vypršení platnosti certifikátu neovlivňuje bajty prezentace, ale má vliv na hodnocení důvěry v certifikát. To, zda podpis zůstane přijatelný, závisí na vaší politice a na tom, zda platné důvěryhodné časové razítko prokazuje, že podepsání proběhlo, když byl certifikát platný. Nespoléhejte se pouze na zobrazený čas podpisu jako na důvěryhodné časové razítko.

**Může být podepsaná prezentace stále upravována?**

Ano. Podepsání soubor neuzamyká. Úprava podepsaného obsahu obvykle způsobí neplatnost existujícího podpisu, takže nejprve dokončete prezentaci a podepište finální revizi.

**Může prezentace obsahovat více než jeden podpis?**

Ano. Přidejte každý podpis do [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/digitalsignatures/) před uložením. Během ověřování zkontrolujte každý podpis a potvrďte, že jsou přítomni všichni požadovaní podepisující.

**Které formáty prezentací podporují tyto operace?**

Aspose.Slides podporuje operace s digitálním podpisem popsané zde pouze pro PPTX. Formáty PPT a OpenDocument presentation nejsou tímto API workflow podporovány.

**Mohu odstranit podpis, aniž by to ovlivnilo snímky?**

Ano. Můžete odstranit jeden podpis nebo vymazat celou kolekci a poté uložit prezentaci. Obsah snímků zůstává zachován, ale uložený soubor již neobsahuje důkaz o odstraněném podpisu.