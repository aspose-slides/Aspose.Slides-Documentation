---
title: Ochrana prezentací heslem v .NET
linktitle: Ochrana heslem
type: docs
weight: 20
url: /cs/net/password-protected-presentation/
keywords:
- prezentace chráněná heslem
- otevírací heslo
- šifrovat PowerPoint
- dešifrovat PowerPoint
- ověřit heslo prezentace
- zkontrolovat heslo prezentace
- otevřít šifrovanou prezentaci
- odstranit šifrování
- PowerPoint
- PPT
- PPTX
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Šifrujte, detekujte, ověřujte, otevírejte a dešifrujte prezentace PowerPoint PPT a PPTX chráněné heslem v C# pomocí Aspose.Slides pro .NET."
---
## **Přehled**

Otevírací heslo šifruje prezentaci. Správné heslo je vyžadováno pro načtení a zobrazení obsahu prezentace, takže tato ochrana poskytuje důvěrnost.

Otevírací heslo se liší od hesla pro ochranu proti zápisu. Ochrana proti zápisu omezuje úpravy, ale nešifruje obsah ani nebrání načtení prezentace. Pro správu hesel pro úpravu prezentací viz [Zapisovat ochranu prezentací](/slides/cs/net/write-protected-presentation/).

Níže uvedené pracovní postupy platí pro prezentace PPT i PPTX. Příklady používají oba formáty, kde je důležité chování založené na souborech i na streamu.

## **Šifrování prezentace otevíracím heslem**

Pomocí [IProtectionManager.Encrypt](https://reference.aspose.com/slides/cs/net/aspose.slides/iprotectionmanager/encrypt/) přiřadíte otevírací heslo. Poté použijte [IPresentation.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/save/) k uložení šifrované prezentace.

Následující příklad šifruje PPTX prezentaci:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Nechat dokumentové vlastnosti veřejné**

Ve výchozím nastavení Aspose.Slides zahrnuje dokumentové vlastnosti do šifrování prezentace. Vlastnost [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) řídí toto chování nezávisle na šifrování obsahu snímků. Před voláním [IProtectionManager.Encrypt](https://reference.aspose.com/slides/cs/net/aspose.slides/iprotectionmanager/encrypt/) ji nastavte na `false`, pokud systém pro indexování, klasifikaci, vyhledávání nebo správu dokumentů musí číst metadata bez otevíracího hesla.

Následující příklad vytváří šifrovanou PPTX prezentaci a přitom ponechává její vestavěné dokumentové vlastnosti veřejné:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var properties = presentation.DocumentProperties;
properties.Author = "Contoso Knowledge Management";
properties.Title = "Quarterly Product Roadmap";
properties.Keywords = "roadmap, planning, internal";

presentation.Slides[0].Name = "Encrypted presentation content";
presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("public-properties-encrypted.pptx", SaveFormat.Pptx);
```

Nastavení `EncryptDocumentProperties` na `false` neznamená, že slajdy, masterové, rozvržení, tvary, média nebo jiný obsah prezentace jsou veřejné. Ovlivňuje pouze dokumentové vlastnosti. Pro čtení těchto vlastností bez načítání šifrovaného obsahu viz [Správa vlastností prezentace](/slides/cs/net/presentation-properties/).

## **Načtení šifrované prezentace**

Nastavte [LoadOptions.Password](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/password/) na otevírací heslo a předávejte možnosti do [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) při načítání souboru. Načtení selže, pokud je požadováno otevírací heslo, ale zadané heslo chybí nebo je nesprávné.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// Pracujte s dešifrovanou prezentací.
```

## **Odstranění šifrování z prezentace**

Načtěte prezentaci s jejím otevíracím heslem, zavolejte [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/cs/net/aspose.slides/iprotectionmanager/removeencryption/) a uložte výsledek. Uložená prezentace pak může být načtena bez hesla.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **Ověření otevíracího hesla před načtením**

Pomocí [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationfactory/getpresentationinfo/) získáte [IPresentationInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/) bez vytvoření úplné instance prezentace. Před požádáním o heslo nebo jeho ověřením zkontrolujte [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/ispasswordprotected/). Pokud je ochrana přítomna, ověřte zadanou hodnotu metodou [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/checkpassword/).

### **Workflow se souborovou cestou**

Následující příklad ověří otevírací heslo pro soubor PPTX, předá ověřenou hodnotu do [LoadOptions.Password](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/password/) a poté načte úplnou prezentaci:

```csharp
using System;
using Aspose.Slides;

var filePath = "protected-presentation.pptx";
var password = "open_password";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(filePath, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Workflow se streamem**

Přetížení pro stream metody [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationfactory/getpresentationinfo/) poskytuje stejný workflow. Před načtením úplné prezentace ze streamu nastavte pozici vyhledávatelného streamu na začátek.

Následující příklad používá soubor PPT:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var password = "open_password";
using var presentationStream = File.OpenRead("protected-presentation.ppt");
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(presentationStream);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    presentationStream.Position = 0;

    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(presentationStream, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Návratové hodnoty CheckPassword**

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/checkpassword/) vrací `true` pouze tehdy, když má prezentace otevírací heslo a zadané heslo je správné. Vrací `false` v každém z následujících případů:

- Heslo je nesprávné.
- Prezentace nemá otevírací heslo.
- Zadané heslo je `null` nebo prázdné.

Chování je stejné pro prezentace PPT i PPTX.

## **Zkontrolujte, zda je načtená prezentace šifrována**

Po načtení prezentace se správným heslem zkontrolujte [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/cs/net/aspose.slides/iprotectionmanager/isencrypted/), abyste potvrdili, že zdrojová prezentace byla šifrována. Pro detekci ochrany otevíracím heslem před načtením použijte `IPresentationInfo.IsPasswordProtected`, jak je uvedeno výše.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **Doporučení pro zabezpečení**

{{% alert color="warning" title="Zabezpečení" %}}
Nezaznamenávejte otevírací hesla ani je nezahrnujte do diagnostických zpráv. Vyhněte se zbytečným opakovaným pokusům o ověření, uchovávejte hesla v paměti jen po nezbytně nutnou dobu a opakovaně použijte úspěšný výsledek ověření při okamžitém načtení prezentace.

Veřejné dokumentové vlastnosti mohou odhalit jména autorů, názvy, předměty, klíčová slova, informace o společnosti, komentáře a vlastní hodnoty, i když je obsah prezentace šifrován. Šifrujte citlivá metadata společně s prezentací. Nechat vlastnosti veřejné by mělo být explicitním rozhodnutím, učiněným jen když systémy musí indexovat, klasifikovat, vyhledávat nebo spravovat soubor bez otevíracího hesla.
{{% /alert %}}

## **Ochrana prezentace heslem online**

1. Otevřete aplikaci [Aspose.Slides Lock](https://products.aspose.app/slides/cs/lock).
2. Vyberte nebo nahrajte prezentaci.
3. Zadejte heslo pro ochranu prohlížením.
4. Volitelně zadejte samostatné heslo pro ochranu úprav.
5. Použijte ochranu a stáhněte vzniklý soubor.

{{% alert color="info" title="Viz také" %}}
- [Zapisovat ochranu prezentací](/slides/cs/net/write-protected-presentation/)
- [Digitální podpis v PowerPointu](/slides/cs/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Jaký je rozdíl mezi otevíracím heslem a heslem pro ochranu proti zápisu?**

Otevírací heslo šifruje prezentaci a je vyžadováno pro načtení jejího obsahu. Heslo pro ochranu proti zápisu omezuje úpravy, aniž by šifrovalo obsah.

**Mohu ověřit otevírací heslo, aniž načtu všechny snímky?**

Ano. Získejte informace o prezentaci, ověřte, zda je přítomna ochrana otevíracím heslem, a ověřte heslo před vytvořením úplné instance prezentace.

**Může aplikace číst metadata bez otevíracího hesla?**

Ano, ale jen pokud byla prezentace šifrována s nastavením `EncryptDocumentProperties` na `false`. Aplikace pak musí použít režim načítání jen dokumentových vlastností popsaný v [Správa vlastností prezentace](/slides/cs/net/presentation-properties/).

**Podporují pracovní postupy ověřování hesla jak PPT, tak PPTX?**

Ano. Detekce a ověřování hesla založené na souborové cestě i na streamu se chovají stejně pro prezentace PPT i PPTX.